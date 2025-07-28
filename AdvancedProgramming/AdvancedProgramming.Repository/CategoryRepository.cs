using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;

namespace AdvancedProgramming.Repository
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category Category);
        void UpdateCategory(Category Category);
        void DeleteCategory(int id);
    }

    public class CategoryRepository : ICategoryRepository

    {
        private readonly ProductDBEntities _context;
  
        public CategoryRepository()
        {
            _context = new ProductDBEntities();
        }

        public void AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var Category = _context.Categories.Find(id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();  
        }

        public Category GetCategoryById(int id)
        {
           return _context.Categories.Find(id);
        }

        public void UpdateCategory(Category Category)
        {
            if(_context.Entry(Category).State == EntityState.Detached)
            {
                _context.Categories.Attach(Category);
            }
            _context.Entry(Category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
