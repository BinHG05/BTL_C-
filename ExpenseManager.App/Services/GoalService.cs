using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IWalletRepository _walletRepository;

        public GoalService(IGoalRepository goalRepository, IWalletRepository walletRepository)
        {
            _goalRepository = goalRepository;
            _walletRepository = walletRepository;
        }

        public async Task<IEnumerable<GoalDTO>> GetUserGoalsAsync(string userId)
        {
            var goals = await _goalRepository.GetGoalsByUserIdAsync(userId);
            var goalDtos = new List<GoalDTO>();

            foreach (var goal in goals)
            {
                var lastMonthDeposit = await _goalRepository.GetLastMonthDepositAsync(goal.GoalId);
                var lastDepositDate = goal.GoalDeposits.OrderByDescending(d => d.DepositDate).FirstOrDefault()?.DepositDate;
                var progressPercentage = goal.TargetAmount > 0
                    ? Math.Round((goal.CurrentAmount / goal.TargetAmount) * 100, 2)
                    : 0;

                goalDtos.Add(new GoalDTO
                {
                    GoalId = goal.GoalId,
                    GoalName = goal.GoalName,
                    TargetAmount = goal.TargetAmount,
                    CurrentAmount = goal.CurrentAmount,
                    ProgressPercentage = progressPercentage,
                    Status = goal.Status,
                    CreatedAt = goal.CreatedAt,
                    UpdatedAt = goal.UpdatedAt,
                    WalletId = goal.WalletId,
                    WalletName = goal.Wallet?.WalletName,
                    CompletionDate = goal.CompletionDate,
                    LastMonthDeposit = lastMonthDeposit,
                    LastDepositDate = lastDepositDate
                });
            }

            return goalDtos;
        }

        public async Task<GoalDTO> GetGoalDetailsAsync(int goalId)
        {
            var goal = await _goalRepository.GetGoalByIdAsync(goalId);
            if (goal == null) return null;

            var lastMonthDeposit = await _goalRepository.GetLastMonthDepositAsync(goalId);
            var lastDepositDate = goal.GoalDeposits.OrderByDescending(d => d.DepositDate).FirstOrDefault()?.DepositDate;
            var progressPercentage = goal.TargetAmount > 0
                ? Math.Round((goal.CurrentAmount / goal.TargetAmount) * 100, 2)
                : 0;

            return new GoalDTO
            {
                GoalId = goal.GoalId,
                GoalName = goal.GoalName,
                TargetAmount = goal.TargetAmount,
                CurrentAmount = goal.CurrentAmount,
                ProgressPercentage = progressPercentage,
                Status = goal.Status,
                CreatedAt = goal.CreatedAt,
                UpdatedAt = goal.UpdatedAt,
                WalletId = goal.WalletId,
                WalletName = goal.Wallet?.WalletName,
                CompletionDate = goal.CompletionDate,
                LastMonthDeposit = lastMonthDeposit,
                LastDepositDate = lastDepositDate
            };
        }

        public async Task<GoalDTO> CreateGoalAsync(CreateGoalDTO createGoalDto)
        {
            var goal = new Goal
            {
                UserId = createGoalDto.UserId,
                GoalName = createGoalDto.GoalName,
                TargetAmount = createGoalDto.TargetAmount,
                CurrentAmount = 0,
                Status = "Active",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CompletionDate = createGoalDto.CompletionDate
            };

            var createdGoal = await _goalRepository.CreateGoalAsync(goal);

            return new GoalDTO
            {
                GoalId = createdGoal.GoalId,
                GoalName = createdGoal.GoalName,
                TargetAmount = createdGoal.TargetAmount,
                CurrentAmount = createdGoal.CurrentAmount,
                ProgressPercentage = 0,
                Status = createdGoal.Status,
                CreatedAt = createdGoal.CreatedAt,
                UpdatedAt = createdGoal.UpdatedAt,
                WalletId = createdGoal.WalletId,
                LastMonthDeposit = 0,
                CompletionDate = createdGoal.CompletionDate
            };
        }

        public async Task<bool> UpdateGoalAsync(UpdateGoalDTO updateGoalDto)
        {
            var goal = await _goalRepository.GetGoalByIdAsync(updateGoalDto.GoalId);
            if (goal == null) return false;

            goal.GoalName = updateGoalDto.GoalName;
            goal.TargetAmount = updateGoalDto.TargetAmount;
            goal.WalletId = updateGoalDto.WalletId;
            goal.CompletionDate = updateGoalDto.CompletionDate;

            if (!string.IsNullOrEmpty(updateGoalDto.Status))
            {
                goal.Status = updateGoalDto.Status;
            }

            return await _goalRepository.UpdateGoalAsync(goal);
        }

        public async Task<bool> DeleteGoalAsync(int goalId)
        {
            return await _goalRepository.DeleteGoalAsync(goalId);
        }
        public async Task<bool> DepositToGoalAsync(GoalDepositDTO depositDto)
        {
            // 1. Lấy dữ liệu
            var wallet = await _walletRepository.GetWalletByIdAsync(depositDto.WalletId);
            var goal = await _goalRepository.GetGoalByIdAsync(depositDto.GoalId);

            if (wallet == null || goal == null) return false;
            if (wallet.Balance < depositDto.Amount) return false;

            // 2. THỰC HIỆN TÍNH TOÁN
            wallet.Balance -= depositDto.Amount;      // Trừ tiền ví
            goal.CurrentAmount += depositDto.Amount;  // Cộng tiền mục tiêu

            // 3. GỌI REPOSITORY ĐỂ UPDATE (QUAN TRỌNG)
            // Bạn phải gọi hàm này thì DB mới biết Ví đã bị trừ tiền
            await _walletRepository.UpdateWallet(wallet);

            // Cập nhật Mục tiêu
            await _goalRepository.UpdateGoalAsync(goal);

            // 4. TẠO LỊCH SỬ (Lưu ý: Chỉ gán ID, KHÔNG gán object Wallet để tránh lỗi Tracking)
            var deposit = new GoalDeposit
            {
                GoalId = depositDto.GoalId,
                UserId = depositDto.UserId,
                WalletId = depositDto.WalletId, // <--- Chỉ gán ID
                Amount = depositDto.Amount,
                Note = depositDto.Note ?? string.Empty,
                DepositDate = DateTime.Now
            };

            // 5. THÊM LỊCH SỬ
            await _goalRepository.AddDepositAsync(deposit);

            return true;
        }

        public async Task<IEnumerable<GoalDepositHistoryDTO>> GetGoalHistoryAsync(int goalId)
        {
            var history = await _goalRepository.GetGoalDepositHistoryAsync(goalId);

            return history.Select(h => new GoalDepositHistoryDTO
            {
                DepositId = h.DepositId,
                DepositDate = h.DepositDate,
                WalletName = h.Wallet?.WalletName ?? "Unknown",
                Note = h.Note,
                Amount = h.Amount
            });
        }

        public async Task<IEnumerable<GoalWalletBalanceDTO>> GetAvailableWalletsAsync(string userId)
        {
            // 1. Lấy dữ liệu thô
            var wallets = await _walletRepository.GetWalletsByUserIdAsync(userId);

            // 2. Kiểm tra null để an toàn (Safe check)
            if (wallets == null)
            {
                return Enumerable.Empty<GoalWalletBalanceDTO>();
            }

            // 3. Lọc và Map dữ liệu
            return wallets

                .OrderByDescending(w => w.Balance) 
                .Select(w => new GoalWalletBalanceDTO
                {
                    WalletId = w.WalletId,
                    WalletName = w.WalletName,
                    Balance = w.Balance
                })
                .ToList();
        }

        public async Task<IEnumerable<GoalContributionDTO>> GetWalletContributionsAsync(int goalId)
        {
            return await _goalRepository.GetWalletContributionsAsync(goalId);
        }
    }
}