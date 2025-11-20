using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Views.Admin.UC
{
    public interface IUserManagementView
    {
        void DisplayUsers(PagedResult<UserDTO> result);
        void DisplayStatistics(UserStatisticsDTO stats);
        void ShowMessage(string message, string title, bool isError = false);
        void ShowLoading(bool isLoading);
        void UpdatePaginationInfo(string info);
        void EnablePagination(bool hasPrevious, bool hasNext);
    }
}