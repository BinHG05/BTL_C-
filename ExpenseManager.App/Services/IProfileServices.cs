using System;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services.Interfaces
{
    public interface IProfileServices
    {
        Task<User?> GetUserProfileAsync(string userId);

        Task<(bool success, string errorMessage)> UpdateGeneralInfoAsync(
            string userId,
            string fullName,
            string? newEmail,
            string? avatarFilePath);

        Task<(bool success, string errorMessage)> UpdateSecurityInfoAsync(
            string userId,
            string currentPassword,
            string? newEmail,
            string? newPassword);

        Task<(bool success, string errorMessage)> UpdatePersonalInfoAsync(
            string userId,
            string? address,
            string? city,
            DateTime? dateOfBirth,
            string? country);
    }
}