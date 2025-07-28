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
    public interface ISupplierRepository
    {
        Supplier GetSupplierById(int id);
        IEnumerable<Supplier> GetAllSuppliers();
        void AddSupplier(Supplier Supplier);
        void UpdateSupplier(Supplier Supplier);
        void DeleteSupplier(int id);
    }

    public class SupplierRepository : ISupplierRepository

    {
        private readonly ProductDBEntities _context;
  
        public SupplierRepository()
        {
            _context = new ProductDBEntities();
        }

        public void AddSupplier(Supplier Supplier)
        {
            _context.Suppliers.Add(Supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var Supplier = _context.Suppliers.Find(id);
            if (Supplier != null)
            {
                _context.Suppliers.Remove(Supplier);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();  
        }

        public Supplier GetSupplierById(int id)
        {
           return _context.Suppliers.Find(id);
        }

        public void UpdateSupplier(Supplier Supplier)
        {
            if(_context.Entry(Supplier).State == EntityState.Detached)
            {
                _context.Suppliers.Attach(Supplier);
            }
            _context.Entry(Supplier).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
