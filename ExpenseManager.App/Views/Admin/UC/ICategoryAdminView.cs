using ExpenseManager.App.Models.DTOs;
using System.Collections.Generic;

namespace ExpenseManager.App.Views.Admin.UC
{
    public interface ICategoryAdminView
    {
        void DisplayIcons(List<IconDTO> icons);
        void DisplayColors(List<ColorDTO> colors);
        void ShowSuccess(string message);
        void ShowError(string message);
    }
}