using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.DTOs
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }

        // Display properties
        public string DisplayId => UserId?.Length > 8 ? UserId.Substring(0, 8) : UserId;
        public string StatusText => IsActive ? "Active" : "Blocked";
        public string LastLoginText => LastLogin.HasValue
            ? LastLogin.Value.ToString("dd/MM/yyyy HH:mm")
            : "Never logged in";
    }

    public class UserStatisticsDTO
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int BlockedUsers { get; set; }
        public int Administrators { get; set; }
    }

    public class UserSearchFilter
    {
        public string SearchText { get; set; } = string.Empty;
        public string RoleFilter { get; set; } = "All Roles";
        public string StatusFilter { get; set; } = "All Status";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 6;
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public int StartIndex => (PageNumber - 1) * PageSize + 1;
        public int EndIndex => Math.Min(PageNumber * PageSize, TotalItems);
    }
}