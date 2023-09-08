using E_ComerceApp.Entities;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

namespace E_CommerceApp.Repositories.Classes
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly E_CommerceEntities _context;

        public CategoryRepository(E_CommerceEntities context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
