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
    public interface IInventoryRepository
    {
        Inventory GetInventoryById(int id);
        IEnumerable<Inventory> GetAllInventory();
        void AddInventory(Inventory Inventory);
        void UpdateInventory(Inventory Inventory);
        void DeleteInventory(int id);
    }

    public class InventoryRepository : IInventoryRepository

    {
        private readonly ProductDBEntities _context;
  
        public InventoryRepository()
        {
            _context = new ProductDBEntities();
        }

        public void AddInventory(Inventory Inventory)
        {
            _context.Inventories.Add(Inventory);
            _context.SaveChanges();
        }

        public void DeleteInventory(int id)
        {
            var Inventory = _context.Inventories.Find(id);
            if (Inventory != null)
            {
                _context.Inventories.Remove(Inventory);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Inventory> GetAllInventory()
        {
            return _context.Inventories.ToList();  
        }

        public Inventory GetInventoryById(int id)
        {
           return _context.Inventories.Find(id);
        }

        public void UpdateInventory(Inventory Inventory)
        {
            if(_context.Entry(Inventory).State == EntityState.Detached)
            {
                _context.Inventories.Attach(Inventory);
            }
            _context.Entry(Inventory).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
