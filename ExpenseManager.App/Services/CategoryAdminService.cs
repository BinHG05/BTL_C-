using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Repositories.Admin;
using System.Collections.Generic;
using System.Linq;
using ColorEntity = ExpenseManager.App.Models.Entities.Color;  // ALIAS
using IconEntity = ExpenseManager.App.Models.Entities.Icon;    // ALIAS

namespace ExpenseManager.App.Services.Admin
{
    public class CategoryAdminService
    {
        private readonly CategoryAdminRepository _repository;

        public CategoryAdminService(ExpenseDbContext dbContext)
        {
            _repository = new CategoryAdminRepository(dbContext);
        }

        public List<IconDTO> GetAllIcons()
        {
            var icons = _repository.GetAllIcons();
            return icons.Select(i => new IconDTO
            {
                IconId = i.IconId,
                IconName = i.IconName,
                IconClass = i.IconClass
            }).ToList();
        }

        public List<ColorDTO> GetAllColors()
        {
            var colors = _repository.GetAllColors();
            return colors.Select(c => new ColorDTO
            {
                ColorId = c.ColorId,
                ColorName = c.ColorName,
                HexCode = c.HexCode
            }).ToList();
        }

        public void AddIcon(IconDTO dto)
        {
            var icon = new IconEntity  // DÙNG ALIAS
            {
                IconName = dto.IconName,
                IconClass = dto.IconClass
            };
            _repository.AddIcon(icon);
        }

        public void AddColor(ColorDTO dto)
        {
            var color = new ColorEntity  // DÙNG ALIAS
            {
                ColorName = dto.ColorName,
                HexCode = dto.HexCode
            };
            _repository.AddColor(color);
        }

        public void DeleteIcon(int iconId)
        {
            _repository.DeleteIcon(iconId);
        }

        public void DeleteColor(int colorId)
        {
            _repository.DeleteColor(colorId);
        }
    }
}