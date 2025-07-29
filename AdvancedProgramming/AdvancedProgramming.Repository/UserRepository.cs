using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;

namespace AdvancedProgramming.Repository
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
        IEnumerable<User> GetAllUser();
        void AddUser(User User);
        void UpdateUser(User User);
        void DeleteUser(int id);
    }

    public class UserRepository : IUserRepository

    {
        private readonly ProductDBEntities _context;

        public UserRepository()
        {
            _context = new ProductDBEntities();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUser(string username, string password) { 
        
                return _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
            }

        public void UpdateUser(User User)
        {
            if (_context.Entry(User).State == EntityState.Detached)
            {
                _context.Users.Attach(User);
            }
            _context.Entry(User).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
