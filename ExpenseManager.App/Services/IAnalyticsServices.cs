using ExpenseManager.App.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IAnalyticsService
    {
        Task<(
            List<ExpenseBreakdownItem> Breakdown,
            List<TransactionDto> History,
            decimal Total,
            List<TrendDataPoint> TrendData,
            PagingInfo Paging)> GetExpenseAnalyticsAsync(
            string userId,
            int? walletId,
            string? month,
            int page = 1,
            int pageSize = 7);

        Task<(
            List<IncomeBreakdownItem> Breakdown,
            List<IncomeTransactionDto> History,
            decimal Total,
            List<TrendDataPoint> TrendData,
            PagingInfo Paging)> GetIncomeAnalyticsAsync(
            string userId,
            int? walletId,
            string? month,
            int page = 1,
            int pageSize = 7);
    }
}