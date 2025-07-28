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
    public interface IProductRepository
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }

    public class ProductRepository : IProductRepository

    {
        private readonly ProductDBEntities _context;
  
        public ProductRepository()
        {
            _context = new ProductDBEntities();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();  
        }

        public Product GetProductById(int id)
        {
           return _context.Products.Find(id);
        }

        public void UpdateProduct(Product product)
        {
            if(_context.Entry(product).State == EntityState.Detached)
            {
                _context.Products.Attach(product);
            }
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
