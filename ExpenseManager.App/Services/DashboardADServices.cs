using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.Enums;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App.Services
{
    /// <summary>
    /// Service chứa logic nghiệp vụ cho Dashboard
    /// Thực hiện tính toán và xử lý dữ liệu từ Repository
    /// </summary>
    public class DashboardADService : IDashboardADService
    {
        private readonly IDashboardADRepository _repository;

        public DashboardADService(IDashboardADRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<KPIStatsDTO> GetKPIStatsAsync()
        {
            var stats = new KPIStatsDTO();

            // Lấy thời gian hiện tại
            var now = DateTime.Now;
            var currentMonthStart = new DateTime(now.Year, now.Month, 1);
            var previousMonthStart = currentMonthStart.AddMonths(-1);

            // ===== USER STATS =====
            stats.TotalUsers = await _repository.CountUsersAsync();
            stats.NewUsersThisMonth = await _repository.CountUsersCreatedInMonthAsync(currentMonthStart);

            // Tính Growth Rate cho Users
            var newUsersLastMonth = await _repository.CountUsersCreatedInMonthAsync(previousMonthStart);
            stats.UserGrowthRate = CalculateGrowthRate(newUsersLastMonth, stats.NewUsersThisMonth);

            // ===== TRANSACTION STATS =====
            stats.TotalTrans = await _repository.CountTransactionsAsync();
            stats.NewTransThisMonth = await _repository.CountTransactionsCreatedInMonthAsync(currentMonthStart);

            // Tính Growth Rate cho Transactions
            var newTransLastMonth = await _repository.CountTransactionsCreatedInMonthAsync(previousMonthStart);
            stats.TransGrowthRate = CalculateGrowthRate(newTransLastMonth, stats.NewTransThisMonth);

            // ===== TICKET STATS =====
            stats.TotalTickets = await _repository.CountTotalTicketsAsync();
            stats.PendingTickets = await _repository.CountPendingTicketsAsync();
            stats.OpenTickets = await _repository.CountOpenTicketsAsync();
            stats.ResolvedTickets = stats.TotalTickets - stats.PendingTickets - stats.OpenTickets;

            return stats;
        }

        public async Task<List<ChartDataPointDTO>> GetUserGrowthDataAsync(string filterType)
        {
            var now = DateTime.Now;
            DateTime startDate;
            DateTime endDate = now;
            AggregationType aggregationType;

            // Xác định khoảng thời gian và kiểu tổng hợp dựa trên filter
            switch (filterType)
            {
                case "Theo ngày":
                    // Lấy dữ liệu 30 ngày gần nhất
                    startDate = now.AddDays(-29).Date;
                    aggregationType = AggregationType.Daily;
                    break;

                case "Theo tháng":
                    // Lấy dữ liệu 12 tháng trong năm hiện tại
                    startDate = new DateTime(now.Year, 1, 1);
                    aggregationType = AggregationType.Monthly;
                    break;

                case "Theo năm":
                    // Lấy dữ liệu 7 năm gần nhất
                    startDate = new DateTime(now.Year - 6, 1, 1);
                    aggregationType = AggregationType.Yearly;
                    break;

                default:
                    // Mặc định là theo tháng
                    startDate = new DateTime(now.Year, 1, 1);
                    aggregationType = AggregationType.Monthly;
                    break;
            }

            // Lấy dữ liệu từ Repository
            var rawData = await _repository.GetUsersCountByDateRangeAsync(
                startDate,
                endDate,
                aggregationType);

            // Chuyển đổi sang DTO
            var chartData = new List<ChartDataPointDTO>();

            // Đảm bảo có đủ điểm dữ liệu, điền 0 cho các khoảng không có data
            if (aggregationType == AggregationType.Daily)
            {
                // Tạo 30 điểm cho 30 ngày
                for (int i = 0; i < 30; i++)
                {
                    var date = startDate.AddDays(i);
                    var label = date.Day.ToString();
                    var value = rawData.ContainsKey(label) ? rawData[label] : 0;

                    chartData.Add(new ChartDataPointDTO
                    {
                        Label = label,
                        Value = value
                    });
                }
            }
            else if (aggregationType == AggregationType.Monthly)
            {
                // Tạo 12 điểm cho 12 tháng
                var monthNames = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

                for (int i = 0; i < 12; i++)
                {
                    var label = monthNames[i];
                    var value = rawData.ContainsKey(label) ? rawData[label] : 0;

                    chartData.Add(new ChartDataPointDTO
                    {
                        Label = label,
                        Value = value
                    });
                }
            }
            else // Yearly
            {
                // Sắp xếp theo năm và lấy dữ liệu có sẵn
                var sortedYears = rawData.Keys.OrderBy(k => k).ToList();

                foreach (var year in sortedYears)
                {
                    chartData.Add(new ChartDataPointDTO
                    {
                        Label = year,
                        Value = rawData[year]
                    });
                }
            }

            return chartData;
        }

        #region Private Helper Methods

        /// <summary>
        /// Tính tỉ lệ tăng trưởng (%)
        /// Formula: ((New - Old) / Old) * 100
        /// </summary>
        private decimal CalculateGrowthRate(int oldValue, int newValue)
        {
            if (oldValue == 0)
            {
                // Nếu tháng trước không có dữ liệu, tỉ lệ tăng là 100% nếu tháng này có
                return newValue > 0 ? 100 : 0;
            }

            var growthRate = ((decimal)(newValue - oldValue) / oldValue) * 100;
            return Math.Round(growthRate, 2);
        }

        #endregion
    }
}