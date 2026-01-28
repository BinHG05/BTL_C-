using System;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Views.User.UC
{
    public interface IProfileView
    {
        string UserId { get; }

        string FullName { get; set; }
        string CurrentEmail { get; }
        string AvatarFilePath { get; }

        string NewEmailInput { get; }
        string CurrentPasswordInput { get; }
        string NewPasswordInput { get; }
        string ConfirmNewPasswordInput { get; }

        string AddressInput { get; }
        string CityInput { get; }
        DateTime? DateOfBirthInput { get; }
        string CountryInput { get; }

        void DisplayUserData(ExpenseManager.App.Models.Entities.User user);

        void ShowSuccess(string message);

        void ShowError(string message);

        event EventHandler SaveGeneralInfoClicked;

        event EventHandler SaveSecurityClicked;

        event EventHandler SavePersonalInfoClicked;
    }
}