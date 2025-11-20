using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager.App.Repositories.Admin
{
    public class CategoryAdminRepository
    {
        private readonly ExpenseDbContext _dbContext;

        public CategoryAdminRepository(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Icon> GetAllIcons()
        {
            return _dbContext.Icons.OrderBy(i => i.IconName).ToList();
        }

        public List<Color> GetAllColors()
        {
            return _dbContext.Colors.OrderBy(c => c.ColorName).ToList();
        }

        public void AddIcon(Icon icon)
        {
            _dbContext.Icons.Add(icon);
            _dbContext.SaveChanges();
        }

        public void AddColor(Color color)
        {
            _dbContext.Colors.Add(color);
            _dbContext.SaveChanges();
        }

        public void DeleteIcon(int iconId)
        {
            var icon = _dbContext.Icons.Find(iconId);
            if (icon != null)
            {
                _dbContext.Icons.Remove(icon);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteColor(int colorId)
        {
            var color = _dbContext.Colors.Find(colorId);
            if (color != null)
            {
                _dbContext.Colors.Remove(color);
                _dbContext.SaveChanges();
            }
        }
    }
}