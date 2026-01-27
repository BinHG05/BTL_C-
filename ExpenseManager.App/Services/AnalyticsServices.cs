using ExpenseManager.App.Repositories;
using ExpenseManager.App.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IAnalyticsRepository _repository;

        public AnalyticsService(IAnalyticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            List<ExpenseBreakdownItem> Breakdown,
            List<TransactionDto> History,
            decimal Total,
            List<TrendDataPoint> TrendData,
            PagingInfo Paging)> GetExpenseAnalyticsAsync(
            string userId,
            int? walletId,
            string? month,
            int page = 1,
            int pageSize = 7)
        {
            // Parse tháng (format: "yyyy-MM")
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (!string.IsNullOrEmpty(month))
            {
                if (DateTime.TryParseExact(month, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedMonth))
                {
                    startDate = new DateTime(parsedMonth.Year, parsedMonth.Month, 1);
                    endDate = startDate.Value.AddMonths(1).AddDays(-1);
                }
            }

            // 1. Lấy Breakdown (Pie Chart Data) - AWAIT và ToList() ngay
            var categorySummaries = (await _repository.GetExpenseSummaryByCategoryAsync(
                userId, walletId, startDate, endDate)).ToList();

            // Tính tổng TRÊN LIST đã materialize (không query DB nữa)
            var totalAmount = categorySummaries.Sum(c => c.TotalAmount);

            var breakdown = categorySummaries.Select(c => new ExpenseBreakdownItem
            {
                CategoryName = c.CategoryName,
                Amount = c.TotalAmount,
                Percentage = totalAmount > 0 ? (double)(c.TotalAmount / totalAmount * 100) : 0,
                ColorHex = c.ColorHex
            }).ToList();

            // 2. Lấy Transaction History với phân trang - AWAIT
            var (transactions, totalCount) = await _repository.GetExpenseTransactionsAsync(
                userId, walletId, startDate, endDate, page, pageSize);

            // Map sang DTO ngay
            var history = transactions.Select(t => new TransactionDto
            {
                TransactionID = t.TransactionId,
                Amount = t.Amount,
                Type = t.Type,
                TransactionDate = t.TransactionDate,
                Description = t.Description,
                Category = t.Category != null ? new CategoryDto
                {
                    CategoryID = t.Category.CategoryId,
                    CategoryName = t.Category.CategoryName,
                    Icon = t.Category.Icon != null ? new IconDto
                    {
                        IconID = t.Category.Icon.IconId,
                        IconClass = t.Category.Icon.IconClass
                    } : null,
                    Color = t.Category.Color != null ? new ColorDto
                    {
                        ColorID = t.Category.Color.ColorId,
                        HexCode = t.Category.Color.HexCode
                    } : null
                } : null
            }).ToList();

            // 3. Lấy Trend Data (daily aggregation cho tháng hiện tại)
            var trendData = await GetExpenseTrendDataAsync(userId, walletId, startDate, endDate);

            // 4. Tính Paging Info
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalPages = totalPages,
                TotalRecords = totalCount
            };

            return (breakdown, history, totalAmount, trendData, pagingInfo);
        }

        public async Task<(
            List<IncomeBreakdownItem> Breakdown,
            List<IncomeTransactionDto> History,
            decimal Total,
            List<TrendDataPoint> TrendData,
            PagingInfo Paging)> GetIncomeAnalyticsAsync(
            string userId,
            int? walletId,
            string? month,
            int page = 1,
            int pageSize = 7)
        {
            // Parse tháng (format: "yyyy-MM")
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (!string.IsNullOrEmpty(month))
            {
                if (DateTime.TryParseExact(month, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedMonth))
                {
                    startDate = new DateTime(parsedMonth.Year, parsedMonth.Month, 1);
                    endDate = startDate.Value.AddMonths(1).AddDays(-1);
                }
            }

            // 1. Lấy Breakdown (Pie Chart Data) - AWAIT và ToList() ngay
            var categorySummaries = (await _repository.GetIncomeSummaryByCategoryAsync(
                userId, walletId, startDate, endDate)).ToList();

            // Tính tổng TRÊN LIST đã materialize (không query DB nữa)
            var totalAmount = categorySummaries.Sum(c => c.TotalAmount);

            var breakdown = categorySummaries.Select(c => new IncomeBreakdownItem
            {
                CategoryName = c.CategoryName,
                Amount = c.TotalAmount,
                Percentage = totalAmount > 0 ? (double)(c.TotalAmount / totalAmount * 100) : 0,
                ColorHex = c.ColorHex
            }).ToList();

            // 2. Lấy Transaction History với phân trang - AWAIT
            var (transactions, totalCount) = await _repository.GetIncomeTransactionsAsync(
                userId, walletId, startDate, endDate, page, pageSize);

            // Map sang DTO ngay
            var history = transactions.Select(t => new IncomeTransactionDto
            {
                TransactionID = t.TransactionId,
                Amount = t.Amount,
                TransactionDate = t.TransactionDate,
                Description = t.Description,
                Category = t.Category != null ? new CategoryDto
                {
                    CategoryID = t.Category.CategoryId,
                    CategoryName = t.Category.CategoryName,
                    Icon = t.Category.Icon != null ? new IconDto
                    {
                        IconID = t.Category.Icon.IconId,
                        IconClass = t.Category.Icon.IconClass
                    } : null,
                    Color = t.Category.Color != null ? new ColorDto
                    {
                        ColorID = t.Category.Color.ColorId,
                        HexCode = t.Category.Color.HexCode
                    } : null
                } : null
            }).ToList();

            // 3. Lấy Trend Data (daily aggregation cho tháng hiện tại)
            var trendData = await GetIncomeTrendDataAsync(userId, walletId, startDate, endDate);

            // 4. Tính Paging Info
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalPages = totalPages,
                TotalRecords = totalCount
            };

            return (breakdown, history, totalAmount, trendData, pagingInfo);
        }

        private async Task<List<TrendDataPoint>> GetExpenseTrendDataAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate)
        {
            var dailySummary = await _repository.GetExpenseDailySummaryAsync(
                userId, walletId, startDate, endDate);

            // Nếu có startDate và endDate, tạo đầy đủ các ngày trong tháng
            if (startDate.HasValue && endDate.HasValue)
            {
                var allDays = new List<TrendDataPoint>();
                var currentDate = startDate.Value;

                while (currentDate <= endDate.Value)
                {
                    var dayData = dailySummary.FirstOrDefault(d => d.Date.Date == currentDate.Date);
                    allDays.Add(new TrendDataPoint
                    {
                        Date = currentDate,
                        Amount = dayData?.Amount ?? 0,
                        Label = currentDate.Day.ToString()
                    });
                    currentDate = currentDate.AddDays(1);
                }

                return allDays;
            }

            // Nếu không có khoảng thời gian, trả về data có sẵn
            return dailySummary.Select(d => new TrendDataPoint
            {
                Date = d.Date,
                Amount = d.Amount,
                Label = d.Date.ToString("dd/MM")
            }).ToList();
        }

        private async Task<List<TrendDataPoint>> GetIncomeTrendDataAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate)
        {
            var dailySummary = await _repository.GetIncomeDailySummaryAsync(
                userId, walletId, startDate, endDate);

            // Nếu có startDate và endDate, tạo đầy đủ các ngày trong tháng
            if (startDate.HasValue && endDate.HasValue)
            {
                var allDays = new List<TrendDataPoint>();
                var currentDate = startDate.Value;

                while (currentDate <= endDate.Value)
                {
                    var dayData = dailySummary.FirstOrDefault(d => d.Date.Date == currentDate.Date);
                    allDays.Add(new TrendDataPoint
                    {
                        Date = currentDate,
                        Amount = dayData?.Amount ?? 0,
                        Label = currentDate.Day.ToString()
                    });
                    currentDate = currentDate.AddDays(1);
                }

                return allDays;
            }

            // Nếu không có khoảng thời gian, trả về data có sẵn
            return dailySummary.Select(d => new TrendDataPoint
            {
                Date = d.Date,
                Amount = d.Amount,
                Label = d.Date.ToString("dd/MM")
            }).ToList();
        }
    }
}