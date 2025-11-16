using ExpenseManager.App.Contracts.ViewModels;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExpenseManager.App.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        // --- HÀM 1 (Hàm cũ - Giữ nguyên) ---
        public async Task<GoalsPageViewModel> GetGoalsPageDataAsync(string userId)
        {
            var goalsFromDb = await _goalRepository.GetGoalsWithDepositsAsync(userId);
            var pageViewModel = new GoalsPageViewModel();

            if (goalsFromDb == null)
            {
                return pageViewModel;
            }

            pageViewModel.GoalsList = goalsFromDb.Select(g => new GoalViewModel
            {
                GoalId = g.GoalId,
                Name = g.GoalName,
                TargetAmount = g.TargetAmount,
                DueDate = g.CompletionDate ?? DateTime.Now.AddDays(30),
                Status = g.Status,
                CurrentAmount = g.CurrentAmount
            }).ToList();

            pageViewModel.Summary = new GoalSummaryModel
            {
                Total = goalsFromDb.Count,
                NotStarted = goalsFromDb.Count(g => g.Status == "Not started"),
                InProgress = goalsFromDb.Count(g => g.Status == "In progress"),
                Finished = goalsFromDb.Count(g => g.Status == "Finished"),
                Canceled = goalsFromDb.Count(g => g.Status == "Canceled")
            };

            return pageViewModel;
        }

        // --- HÀM 2 (Hàm cũ - Giữ nguyên) ---
        public async Task CreateGoalAsync(string name, decimal targetAmount, DateTime completionDate)
        {
            string currentUserId = CurrentUserSession.CurrentUser?.UserId;
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User session not found. Please log in again.");
            }

            var newGoal = new Goal
            {
                UserId = currentUserId,
                GoalName = name,
                TargetAmount = targetAmount,
                CurrentAmount = 0,
                CompletionDate = completionDate,
                Status = "Not started",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _goalRepository.AddGoalAsync(newGoal);
        }

        // --- HÀM 3 (Hàm cũ - Giữ nguyên) ---
        public async Task<GoalViewModel> GetGoalViewModelByIdAsync(int goalId)
        {
            var goalFromDb = await _goalRepository.GetGoalByIdAsync(goalId);

            if (goalFromDb == null)
            {
                throw new Exception("Goal not found.");
            }

            var viewModel = new GoalViewModel
            {
                GoalId = goalFromDb.GoalId,
                Name = goalFromDb.GoalName,
                TargetAmount = goalFromDb.TargetAmount,
                DueDate = goalFromDb.CompletionDate ?? DateTime.Today,
                Status = goalFromDb.Status,
                CurrentAmount = goalFromDb.CurrentAmount
            };

            return viewModel;
        }

        // --- HÀM 4 (Hàm cũ - Giữ nguyên) ---
        public async Task UpdateGoalAsync(int goalId, string name, decimal targetAmount, DateTime completionDate)
        {
            string currentUserId = CurrentUserSession.CurrentUser?.UserId;
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User session not found.");
            }

            var goalToUpdate = await _goalRepository.GetGoalByIdAsync(goalId);
            if (goalToUpdate == null)
            {
                throw new Exception("Goal not found.");
            }

            if (goalToUpdate.UserId != currentUserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to edit this goal.");
            }

            goalToUpdate.GoalName = name;
            goalToUpdate.TargetAmount = targetAmount;
            goalToUpdate.CompletionDate = completionDate;
            goalToUpdate.UpdatedAt = DateTime.UtcNow;

            await _goalRepository.UpdateGoalAsync(goalToUpdate);
        }

        // --- HÀM MỚI 5 (Triển khai Interface File 5/13) ---
        public async Task DeleteGoalAsync(int goalId)
        {
            // 1. Lấy UserId từ Session
            string currentUserId = CurrentUserSession.CurrentUser?.UserId;
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User session not found.");
            }

            // 2. Lấy Goal (để kiểm tra quyền sở hữu)
            var goalToDelete = await _goalRepository.GetGoalByIdAsync(goalId);
            if (goalToDelete == null)
            {
                // Không tìm thấy, có thể đã bị xóa rồi
                return;
            }

            // 3. KIỂM TRA BẢO MẬT (Rất quan trọng)
            if (goalToDelete.UserId != currentUserId)
            {
                // Người dùng này không sở hữu Goal này -> Cấm truy cập
                throw new UnauthorizedAccessException("You do not have permission to delete this goal.");
            }

            // 4. Ủy quyền cho Repository (File 2/13) để xóa
            await _goalRepository.DeleteGoalAsync(goalId);
        }
    }
}