using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Session; // Cần cho CurrentUserSession
using System; // Cần cho UnauthorizedAccessException
using System.Collections.Generic;
using System.Threading.Tasks;
// using ExpenseManager.App.Contracts.Services; // (Nếu bạn đã dọn dẹp)

namespace ExpenseManager.App.Services
{
    // Triển khai Interface (File 3/10)
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        // Tiêm (Inject) Repository (File 2/10)
        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        // Triển khai hàm
        public async Task<List<Wallet>> GetWalletsForCurrentUserAsync()
        {
            // 1. Lấy UserId từ Session (mà Login đã lưu)
            string currentUserId = CurrentUserSession.CurrentUser?.UserId;

            if (string.IsNullOrEmpty(currentUserId))
            {
                // Nếu User chưa đăng nhập mà vào được đây, đây là lỗi nghiêm trọng
                throw new UnauthorizedAccessException("Không tìm thấy phiên người dùng. Vui lòng đăng nhập lại.");
            }

            // 2. Ủy quyền cho Repository (File 2/10) để lấy dữ liệu
            return await _walletRepository.GetWalletsByUserIdAsync(currentUserId);
        }
    }
}