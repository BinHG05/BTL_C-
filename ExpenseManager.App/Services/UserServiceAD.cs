using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IUserServiceAD
    {
        Task<PagedResult<UserDTO>> GetUsersAsync(UserSearchFilter filter);
        Task<UserStatisticsDTO> GetStatisticsAsync();
        Task<bool> ToggleUserStatusAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);
    }

    public class UserServiceAD : IUserServiceAD
    {
        private readonly IUserRepositoryAD _repository;

        public UserServiceAD(IUserRepositoryAD repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PagedResult<UserDTO>> GetUsersAsync(UserSearchFilter filter)
        {
            try
            {
                return await _repository.GetUsersAsync(filter);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting users: {ex.Message}", ex);
            }
        }

        public async Task<UserStatisticsDTO> GetStatisticsAsync()
        {
            try
            {
                return await _repository.GetStatisticsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting statistics: {ex.Message}", ex);
            }
        }

        public async Task<bool> ToggleUserStatusAsync(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentException("User ID cannot be empty");

                return await _repository.ToggleUserStatusAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error toggling user status: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentException("User ID cannot be empty");

               
                var user = await _repository.GetUserByIdAsync(userId);
                if (user == null)
                    throw new Exception("User not found");

                if (user.Role == "Admin")
                {
                    var stats = await _repository.GetStatisticsAsync();
                    if (stats.Administrators <= 1)
                        throw new Exception("Cannot delete the last administrator");
                }

                return await _repository.DeleteUserAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting user: {ex.Message}", ex);
            }
        }
    }
}