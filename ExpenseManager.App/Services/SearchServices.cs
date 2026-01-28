using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ISearchRepository _repository;

        public SearchServices(ISearchRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Transaction>> SearchTransactionsAsync(
            string userId,
            string keyword,
            string type,
            int? categoryId,
            DateTime fromDate,
            DateTime toDate)
        {
            System.Diagnostics.Debug.WriteLine("=== SearchTransactionsAsync ===");
            System.Diagnostics.Debug.WriteLine($"UserId: {userId}");
            System.Diagnostics.Debug.WriteLine($"Keyword: '{keyword}'");
            System.Diagnostics.Debug.WriteLine($"Type: '{type}'");
            System.Diagnostics.Debug.WriteLine($"CategoryId: {categoryId}");
            System.Diagnostics.Debug.WriteLine($"FromDate: {fromDate:yyyy-MM-dd}");
            System.Diagnostics.Debug.WriteLine($"ToDate: {toDate:yyyy-MM-dd}");

            var transactions = await _repository.GetTransactionsByUserIdAsync(userId);

            System.Diagnostics.Debug.WriteLine($"Total transactions from DB: {transactions?.Count ?? 0}");

            if (transactions != null && transactions.Any())
            {
                var sampleTypes = transactions.Take(5).Select(t => $"[{t.Type}]").ToList();
                System.Diagnostics.Debug.WriteLine($"Sample Types from DB: {string.Join(", ", sampleTypes)}");
            }

            if (transactions == null || transactions.Count == 0)
                return new List<Transaction>();

            var originalCount = transactions.Count;

            transactions = transactions.Where(t =>
                t.TransactionDate.Date >= fromDate.Date &&
                t.TransactionDate.Date <= toDate.Date).ToList();

            System.Diagnostics.Debug.WriteLine($"After date filter: {transactions.Count} (from {originalCount})");

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var beforeKeyword = transactions.Count;
                transactions = transactions.Where(t =>
                    t.Description != null &&
                    t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                System.Diagnostics.Debug.WriteLine($"After keyword filter: {transactions.Count} (from {beforeKeyword})");
            }

            if (!string.IsNullOrWhiteSpace(type) && type != "Tất cả")
            {
                var beforeType = transactions.Count;
                transactions = transactions.Where(t =>
                    t.Type != null &&
                    t.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
                System.Diagnostics.Debug.WriteLine($"After type filter '{type}': {transactions.Count} (from {beforeType})");

                if (transactions.Count == 0 && beforeType > 0)
                {
                    var allTypes = await _repository.GetTransactionsByUserIdAsync(userId);
                    var uniqueTypes = allTypes.Select(t => t.Type).Distinct().ToList();
                    System.Diagnostics.Debug.WriteLine($"Available Types in DB: {string.Join(", ", uniqueTypes)}");
                }
            }

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                var beforeCategory = transactions.Count;
                transactions = transactions.Where(t => t.CategoryId == categoryId.Value).ToList();
                System.Diagnostics.Debug.WriteLine($"After category filter: {transactions.Count} (from {beforeCategory})");
            }

            System.Diagnostics.Debug.WriteLine($"Final result count: {transactions.Count}");
            System.Diagnostics.Debug.WriteLine("==============================");

            return transactions.OrderByDescending(t => t.TransactionDate).ToList();
        }

        public async Task<List<Category>> GetUserCategoriesAsync(string userId)
        {
            var categories = await _repository.GetCategoriesByUserIdAsync(userId);
            System.Diagnostics.Debug.WriteLine($"Categories loaded: {categories?.Count ?? 0}");
            if (categories != null)
            {
                foreach (var cat in categories)
                {
                    System.Diagnostics.Debug.WriteLine($"  - {cat.CategoryId}: {cat.CategoryName}");
                }
            }
            return categories ?? new List<Category>();
        }
    }
}