using System;

namespace ExpenseManager.App.Models.DTOs
{
    // DTO hiển thị thông tin Goal
    public class GoalDTO
    {
        public int GoalId { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal ProgressPercentage { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? WalletId { get; set; }
        public string WalletName { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal LastMonthDeposit { get; set; }
        public DateTime? LastDepositDate { get; set; }
    }

    // DTO tạo mới Goal
    public class CreateGoalDTO
    {
        public string UserId { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime? CompletionDate { get; set; }
    }

    // DTO cập nhật Goal
    public class UpdateGoalDTO
    {
        public int GoalId { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public int? WalletId { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
    }

    // DTO nạp tiền Goal
    public class GoalDepositDTO
    {
        public int GoalId { get; set; }
        public string UserId { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
    }

    // DTO hiển thị lịch sử Goal
    public class GoalDepositHistoryDTO
    {
        public int DepositId { get; set; }
        public DateTime DepositDate { get; set; }
        public string WalletName { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
    }

    // DTO hiển thị wallet balance cho Goal
    public class GoalWalletBalanceDTO
    {
        public int WalletId { get; set; }
        public string WalletName { get; set; }
        public decimal Balance { get; set; }
    }
}