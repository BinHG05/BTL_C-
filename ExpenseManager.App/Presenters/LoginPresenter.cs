using ExpenseManager.App.Services;
using ExpenseManager.App.Views;
using System;
using System.Threading.Tasks;
using ExpenseManager.App.Session;

namespace ExpenseManager.App.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IUserService _service;
        private bool _isBusy = false;

        public LoginPresenter(ILoginView view, IUserService service)
        {
            _view = view;
            _service = service;

            // Đăng ký (subscribe) vào các sự kiện (events) MỚI của View
            _view.LoginClicked += OnLoginClicked;
            _view.CreateAccountClicked += OnCreateAccountClicked;

            // Xóa logic cũ
            // _view.LoginOrRegisterClicked -= OnLoginOrRegisterClicked;
            // _view.SwitchModeClicked -= OnSwitchModeClicked;
        }

        // Xử lý sự kiện khi người dùng click nút "Create an account"
        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            // Ra lệnh cho View mở Form Đăng ký
            _view.ShowRegisterForm();
        }

        // Xử lý sự kiện khi người dùng click nút "Sign In"
        // Đây là một event handler, nó phải là 'async void'
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (_isBusy) return;
            _isBusy = true;

            try
            {
                // Chỉ xử lý Đăng nhập
                await HandleLoginAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                _isBusy = false;
            }
        }

        // Logic xử lý Đăng nhập (Giữ nguyên)
        private async Task HandleLoginAsync()
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(_view.Email) || string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowError("Email and Password are required.");
                return;
            }

            try
            {
                // 2. Gọi Service
                var user = await _service.LoginAsync(_view.Email, _view.Password);

                // 3. Xử lý kết quả
                if (user == null)
                {
                    _view.ShowError("Invalid email or password.");
                }
                else
                {
                    // (Lưu ý: Bạn có thể muốn lưu 'user.UserId' vào một biến static toàn cục ở đây)
                    CurrentUserSession.SetUser(user);

                    _view.ShowSuccess($"Welcome back, {user.FullName}!");
                    // Yêu cầu View chuyển sang màn hình chính
                    _view.NavigateToMain();
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Login failed: {ex.Message}");
            }
        }

    }
}