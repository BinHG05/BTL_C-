using System;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Views.User.UC
{
    /// <summary>
    /// Interface cho Profile View - định nghĩa các thuộc tính và sự kiện mà Presenter cần tương tác
    /// </summary>
    public interface IProfileView
    {
        // ===== THUỘC TÍNH HIỂN THỊ/NHẬN DỮ LIỆU =====

        /// <summary>
        /// ID của người dùng hiện tại
        /// </summary>
        string UserId { get; }

        // ----- Thông tin chung (General Info) -----
        string FullName { get; set; }
        string CurrentEmail { get; }
        string AvatarFilePath { get; }

        // ----- Thông tin bảo mật (Security Info) -----
        string NewEmailInput { get; }
        string CurrentPasswordInput { get; }
        string NewPasswordInput { get; }
        string ConfirmNewPasswordInput { get; }

        // ----- Thông tin cá nhân (Personal Info) -----
        string AddressInput { get; }
        string CityInput { get; }
        DateTime? DateOfBirthInput { get; }
        string CountryInput { get; }

        // ===== PHƯƠNG THỨC THÔNG BÁO =====

        /// <summary>
        /// Hiển thị dữ liệu người dùng lên View
        /// </summary>
        void DisplayUserData(ExpenseManager.App.Models.Entities.User user);

        /// <summary>
        /// Hiển thị thông báo thành công
        /// </summary>
        void ShowSuccess(string message);

        /// <summary>
        /// Hiển thị thông báo lỗi
        /// </summary>
        void ShowError(string message);

        // ===== SỰ KIỆN (EVENTS) =====

        /// <summary>
        /// Sự kiện khi người dùng nhấn Save ở phần General Info (Profile)
        /// </summary>
        event EventHandler SaveGeneralInfoClicked;

        /// <summary>
        /// Sự kiện khi người dùng nhấn Save ở phần Security (Password & Email)
        /// </summary>
        event EventHandler SaveSecurityClicked;

        /// <summary>
        /// Sự kiện khi người dùng nhấn Save ở phần Personal Info
        /// </summary>
        event EventHandler SavePersonalInfoClicked;
    }
}