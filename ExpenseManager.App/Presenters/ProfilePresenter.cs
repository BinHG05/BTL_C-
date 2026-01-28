using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User.UC;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    /// Presenter xử lý logic điều khiển cho Profile View
    public class ProfilePresenter
    {
        private readonly IProfileView _view;
        private readonly IProfileServices _services;

        public ProfilePresenter(IProfileView view, IProfileServices services)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _services = services ?? throw new ArgumentNullException(nameof(services));

            // Đăng ký các sự kiện từ View
            _view.SaveGeneralInfoClicked += View_SaveGeneralInfoClicked;
            _view.SaveSecurityClicked += View_SaveSecurityClicked;
            _view.SavePersonalInfoClicked += View_SavePersonalInfoClicked;
        }

        /// Load dữ liệu User và hiển thị lên View
        public async Task LoadUserProfileAsync()
        {
            try
            {
                string userId = _view.UserId;
                if (string.IsNullOrWhiteSpace(userId))
                {
                    _view.ShowError("Không tìm thấy thông tin người dùng");
                    return;
                }

                var user = await _services.GetUserProfileAsync(userId);
                if (user == null)
                {
                    _view.ShowError("Không thể tải thông tin người dùng");
                    return;
                }

                // Hiển thị dữ liệu lên View
                _view.DisplayUserData(user);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        /// Xử lý sự kiện Save General Info (Profile Panel)
        private async void View_SaveGeneralInfoClicked(object? sender, EventArgs e)
        {
            try
            {
                string userId = _view.UserId;
                string fullName = _view.FullName;
                string avatarPath = _view.AvatarFilePath;

                var (success, errorMessage) = await _services.UpdateGeneralInfoAsync(
                    userId,
                    fullName,
                    null,  
                    avatarPath);

                if (success)
                {
                    _view.ShowSuccess("Cập nhật thông tin thành công!");

                    var updatedUser = await _services.GetUserProfileAsync(userId);
                    if (updatedUser != null)
                    {
                        CurrentUserSession.SetUser(updatedUser);
                    }
                    await LoadUserProfileAsync();
                }
                else
                {
                    _view.ShowError(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi khi lưu thông tin: {ex.Message}");
            }
        }

        /// Xử lý sự kiện Save Security Info (Password Panel)
        private async void View_SaveSecurityClicked(object? sender, EventArgs e)
        {
            try
            {
                string userId = _view.UserId;
                string currentPassword = _view.CurrentPasswordInput;
                string newEmail = _view.NewEmailInput;
                string newPassword = _view.NewPasswordInput;
                string confirmPassword = _view.ConfirmNewPasswordInput;

                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    if (newPassword != confirmPassword)
                    {
                        _view.ShowError("Mật khẩu xác nhận không khớp");
                        return;
                    }
                }

                var (success, errorMessage) = await _services.UpdateSecurityInfoAsync(
                    userId,
                    currentPassword,
                    newEmail,
                    newPassword);

                if (success)
                {
                    _view.ShowSuccess("Cập nhật thông tin bảo mật thành công!");

                    var updatedUser = await _services.GetUserProfileAsync(userId);
                    if (updatedUser != null)
                    {

                        CurrentUserSession.SetUser(updatedUser);
                    }
                    await LoadUserProfileAsync();
                }
                else
                {
                    _view.ShowError(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi khi lưu thông tin bảo mật: {ex.Message}");
            }
        }

        /// Xử lý sự kiện Save Personal Info
        private async void View_SavePersonalInfoClicked(object? sender, EventArgs e)
        {
            try
            {
                string userId = _view.UserId;
                string address = _view.AddressInput;
                string city = _view.CityInput;
                DateTime? dateOfBirth = _view.DateOfBirthInput;
                string country = _view.CountryInput;

                var (success, errorMessage) = await _services.UpdatePersonalInfoAsync(
                    userId,
                    address,
                    city,
                    dateOfBirth,
                    country);

                if (success)
                {
                    _view.ShowSuccess("Cập nhật thông tin cá nhân thành công!");

                    var updatedUser = await _services.GetUserProfileAsync(userId);
                    if (updatedUser != null)
                    {
                        CurrentUserSession.SetUser(updatedUser);
                    }
                    await LoadUserProfileAsync();
                }
                else
                {
                    _view.ShowError(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi khi lưu thông tin cá nhân: {ex.Message}");
            }
        }

        /// Hủy đăng ký các sự kiện khi dispose
        public void Dispose()
        {
            _view.SaveGeneralInfoClicked -= View_SaveGeneralInfoClicked;
            _view.SaveSecurityClicked -= View_SaveSecurityClicked;
            _view.SavePersonalInfoClicked -= View_SavePersonalInfoClicked;
        }
    }
}