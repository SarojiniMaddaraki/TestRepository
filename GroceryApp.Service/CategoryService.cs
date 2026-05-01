using GroceryApp.DAL;
using GroceryApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryApp.Service
{
    public class CategoryService
    {
        private readonly GroceryAppDbContext _context;
        public CategoryService(GroceryAppDbContext context)
        {
            _context = context;
        }

        public List<CategoryModel> GetCategories(int pageIndex, int pageSize)
        {
            return _context.Categories.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public CategoryModel GetCategoryById(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public void AddCategory(CategoryModel category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                _context.Categories.Remove(category);
            }
            _context.SaveChanges();
        }

        public void UpdateCategory(CategoryModel category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
