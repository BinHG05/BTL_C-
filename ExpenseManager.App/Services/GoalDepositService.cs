using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Session;
using System;
using System.Threading.Tasks;
// using ExpenseManager.App.Contracts.Repositories; 
// using ExpenseManager.App.Contracts.Services; 

namespace ExpenseManager.App.Services
{
    // Triển khai Interface (File 5/10)
    public class GoalDepositService : IGoalDepositService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IGoalDepositRepository _goalDepositRepository;

        public GoalDepositService(IGoalRepository goalRepository, IGoalDepositRepository goalDepositRepository)
        {
            _goalRepository = goalRepository;
            _goalDepositRepository = goalDepositRepository;
        }

        // Triển khai hàm AddDepositAsync (File 5/10)
        public async Task AddDepositAsync(int goalId, int walletId, decimal amount)
        {
            // 1. Lấy UserId từ Session
            string currentUserId = CurrentUserSession.CurrentUser?.UserId;
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User session not found.");
            }

            // 2. Lấy Goal (cha) từ CSDL
            var goal = await _goalRepository.GetGoalByIdAsync(goalId);
            if (goal == null)
            {
                throw new Exception("Goal not found.");
            }

            // 3. KIỂM TRA BẢO MẬT
            if (goal.UserId != currentUserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to add a deposit to this goal.");
            }

            // 4. Kiểm tra logic nghiệp vụ
            if (amount <= 0)
            {
                throw new Exception("Số tiền nạp phải lớn hơn 0.");
            }

            if (goal.Status == "Finished")
            {
                throw new Exception("Mục tiêu này đã hoàn thành và không thể nhận thêm tiền nạp.");
            }

            // 5. Tạo một Khoản nạp (Deposit) mới
            var newDeposit = new GoalDeposit
            {
                GoalId = goalId,
                UserId = currentUserId,
                Amount = amount,
                DepositDate = DateTime.UtcNow,
                WalletId = walletId,

                // *** ĐÂY LÀ PHẦN SỬA LỖI CSDL CỦA BẠN ***
                // Cung cấp một giá trị mặc định cho cột 'Note' (NOT NULL)
                Note = "Nạp tiền cho mục tiêu" // (Bạn có thể đổi thành string.Empty nếu muốn)
            };

            // 6. Lưu khoản nạp mới (sử dụng Repo 4/10)
            await _goalDepositRepository.AddAsync(newDeposit);

            // 7. Cập nhật Goal (cha)
            goal.CurrentAmount += amount;
            goal.UpdatedAt = DateTime.UtcNow;

            // 8. Kiểm tra xem đã hoàn thành mục tiêu chưa
            if (goal.CurrentAmount >= goal.TargetAmount)
            {
                goal.Status = "Finished";
            }
            else
            {
                goal.Status = "In progress";
            }

            // 9. Lưu Goal (cha) đã cập nhật
            await _goalRepository.UpdateGoalAsync(goal);
        }
    }
}