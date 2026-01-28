using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.Admin.UC;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class UserManagementPresenter
    {
        private readonly IUserManagementView _view;
        private readonly IUserServiceAD _userService;
        private UserSearchFilter _currentFilter;

        public UserManagementPresenter(IUserManagementView view, IUserServiceAD userService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            _currentFilter = new UserSearchFilter
            {
                PageNumber = 1,
                PageSize = 6,
                RoleFilter = "All Roles",
                StatusFilter = "All Status"
            };
        }

        public async Task InitializeAsync()
        {
            try
            {
                _view.ShowLoading(true);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to initialize: {ex.Message}", "Error", true);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task LoadDataAsync()
        {
            try
            {
                var usersResult = await _userService.GetUsersAsync(_currentFilter);
                _view.DisplayUsers(usersResult);

                var stats = await _userService.GetStatisticsAsync();
                _view.DisplayStatistics(stats);

                _view.UpdatePaginationInfo($"Showing {usersResult.StartIndex} to {usersResult.EndIndex} of {usersResult.TotalItems} users");
                _view.UpdatePaginationInfo($"Page {usersResult.PageNumber} of {usersResult.TotalPages}");
                _view.EnablePagination(usersResult.PageNumber > 1, usersResult.PageNumber < usersResult.TotalPages);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to load data: {ex.Message}", "Error", true);
            }
        }

        public async Task SearchAsync(string searchText)
        {
            try
            {
                _view.ShowLoading(true);
                _currentFilter.SearchText = searchText;
                _currentFilter.PageNumber = 1;
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Search failed: {ex.Message}", "Error", true);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task FilterByRoleAsync(string role)
        {
            try
            {
                _view.ShowLoading(true);
                _currentFilter.RoleFilter = role;
                _currentFilter.PageNumber = 1;
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Filter failed: {ex.Message}", "Error", true);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task FilterByStatusAsync(string status)
        {
            try
            {
                _view.ShowLoading(true);
                _currentFilter.StatusFilter = status;
                _currentFilter.PageNumber = 1; 
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Filter failed: {ex.Message}", "Error", true);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task RefreshAsync()
        {
            try
            {
                _view.ShowLoading(true);

                _currentFilter = new UserSearchFilter
                {
                    PageNumber = 1,
                    PageSize = 6,
                    RoleFilter = "All Roles",
                    StatusFilter = "All Status"
                };

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Refresh failed: {ex.Message}", "Error", true);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task GoToPageAsync(int pageNumber)
        {
            try
            {
                if (pageNumber < 1)
                {
                    _view.ShowMessage("Invalid page number", "Error", true);
                    return;
                }

                _view.ShowLoading(true);
                _currentFilter.PageNumber = pageNumber;
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Navigation failed: {ex.Message}", "Error", true);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task ToggleUserStatusAsync(string userId, string userName)
        {
            try
            {
                _view.ShowLoading(true);

                var success = await _userService.ToggleUserStatusAsync(userId);

                if (success)
                {
                    _view.ShowMessage(
                        $"User '{userName}' status has been toggled successfully!",
                        "Success"
                    );
                    await LoadDataAsync(); 
                }
                else
                {
                    _view.ShowMessage(
                        $"Failed to toggle status for '{userName}'",
                        "Error",
                        true
                    );
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage(
                    $"Failed to toggle user status: {ex.Message}",
                    "Error",
                    true
                );
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task DeleteUserAsync(string userId, string userName)
        {
            try
            {
                _view.ShowLoading(true);

                var success = await _userService.DeleteUserAsync(userId);

                if (success)
                {
                    _view.ShowMessage(
                        $"User '{userName}' has been deleted successfully!",
                        "Success"
                    );
                    await LoadDataAsync(); 
                }
                else
                {
                    _view.ShowMessage(
                        $"Failed to delete '{userName}'",
                        "Error",
                        true
                    );
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage(
                    $"Failed to delete user: {ex.Message}",
                    "Error",
                    true
                );
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }
    }
}