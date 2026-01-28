using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Repositories
{
    /// Repository thực hiện các truy vấn dữ liệu thô từ database
    /// Sử dụng EF Core để truy cập dữ liệu
    public class DashboardADRepository : IDashboardADRepository
    {
        private readonly DbContext _context;

        public DashboardADRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region User Queries

        public async Task<int> CountUsersAsync()
        {
            return await _context.Set<User>().CountAsync();
        }

        public async Task<int> CountUsersCreatedInMonthAsync(DateTime monthStart)
        {
            // Tính ngày đầu và cuối của tháng
            var monthEnd = monthStart.AddMonths(1).AddDays(-1).Date.AddDays(1).AddTicks(-1);

            return await _context.Set<User>()
                .Where(u => u.CreatedAt >= monthStart && u.CreatedAt <= monthEnd)
                .CountAsync();
        }

        public async Task<Dictionary<string, int>> GetUsersCountByDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            AggregationType type)
        {
            var users = await _context.Set<User>()
                .Where(u => u.CreatedAt >= startDate && u.CreatedAt <= endDate)
                .OrderBy(u => u.CreatedAt)
                .ToListAsync();

            var result = new Dictionary<string, int>();

            switch (type)
            {
                case AggregationType.Daily:
                    // Nhóm theo ngày
                    var dailyGroups = users
                        .GroupBy(u => u.CreatedAt.Date)
                        .OrderBy(g => g.Key);

                    foreach (var group in dailyGroups)
                    {
                        string label = group.Key.Day.ToString();
                        result[label] = group.Count();
                    }
                    break;

                case AggregationType.Monthly:
                    // Nhóm theo tháng
                    var monthlyGroups = users
                        .GroupBy(u => new { u.CreatedAt.Year, u.CreatedAt.Month })
                        .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month);

                    foreach (var group in monthlyGroups)
                    {
                        string label = CultureInfo.CurrentCulture.DateTimeFormat
                            .GetAbbreviatedMonthName(group.Key.Month);
                        result[label] = group.Count();
                    }
                    break;

                case AggregationType.Yearly:
                    // Nhóm theo năm
                    var yearlyGroups = users
                        .GroupBy(u => u.CreatedAt.Year)
                        .OrderBy(g => g.Key);

                    foreach (var group in yearlyGroups)
                    {
                        string label = group.Key.ToString();
                        result[label] = group.Count();
                    }
                    break;
            }

            return result;
        }

        #endregion

        #region Transaction Queries

        public async Task<int> CountTransactionsAsync()
        {
            return await _context.Set<Transaction>().CountAsync();
        }

        public async Task<int> CountTransactionsCreatedInMonthAsync(DateTime monthStart)
        {
            var monthEnd = monthStart.AddMonths(1).AddDays(-1).Date.AddDays(1).AddTicks(-1);

            return await _context.Set<Transaction>()
                .Where(t => t.CreatedAt >= monthStart && t.CreatedAt <= monthEnd)
                .CountAsync();
        }

        #endregion

        #region Ticket Queries

        public async Task<int> CountTotalTicketsAsync()
        {
            return await _context.Set<Ticket>().CountAsync();
        }

        public async Task<int> CountPendingTicketsAsync()
        {
            return await _context.Set<Ticket>()
                .Where(t => t.Status == "Pending")
                .CountAsync();
        }

        public async Task<int> CountOpenTicketsAsync()
        {
            return await _context.Set<Ticket>()
                .Where(t => t.Status == "Open")
                .CountAsync();
        }

        public async Task<int> CountResolvedTicketsAsync()
        {
            return await _context.Set<Ticket>()
                 .Where(t => t.Status == "Resolved")
                 .CountAsync();
        }

        #endregion
    }
}