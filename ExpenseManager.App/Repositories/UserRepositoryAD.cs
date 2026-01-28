using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public interface IUserRepositoryAD
    {
        Task<PagedResult<UserDTO>> GetUsersAsync(UserSearchFilter filter);
        Task<UserStatisticsDTO> GetStatisticsAsync();
        Task<bool> ToggleUserStatusAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);
        Task<User> GetUserByIdAsync(string userId);
    }

    public class UserRepositoryAD : IUserRepositoryAD
    {
        private readonly ExpenseDbContext _context;

        public UserRepositoryAD(ExpenseDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PagedResult<UserDTO>> GetUsersAsync(UserSearchFilter filter)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                var searchLower = filter.SearchText.ToLower();
                query = query.Where(u =>
                    u.FullName.ToLower().Contains(searchLower) ||
                    u.Email.ToLower().Contains(searchLower) ||
                    u.UserId.ToLower().Contains(searchLower)
                );
            }

            if (filter.RoleFilter != "All Roles")
            {
                query = query.Where(u => u.Role == filter.RoleFilter);
            }

            if (filter.StatusFilter == "Active")
            {
                query = query.Where(u => u.IsActive);
            }
            else if (filter.StatusFilter == "Blocked")
            {
                query = query.Where(u => !u.IsActive);
            }

            var totalItems = await query.CountAsync();

            var users = await query
                .OrderByDescending(u => u.CreatedAt)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Email = u.Email,
                    FullName = u.FullName,
                    AvatarUrl = u.AvatarUrl,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    LastLogin = u.LastLogin,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();

            return new PagedResult<UserDTO>
            {
                Items = users,
                TotalItems = totalItems,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        public async Task<UserStatisticsDTO> GetStatisticsAsync()
        {
            var stats = new UserStatisticsDTO
            {
                TotalUsers = await _context.Users.CountAsync(),
                ActiveUsers = await _context.Users.CountAsync(u => u.IsActive),
                BlockedUsers = await _context.Users.CountAsync(u => !u.IsActive),
                Administrators = await _context.Users.CountAsync(u => u.Role == "Admin")
            };

            return stats;
        }

        public async Task<bool> ToggleUserStatusAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}