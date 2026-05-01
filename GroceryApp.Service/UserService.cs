using GroceryApp.DAL;
using GroceryApp.Model;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryApp.Service
{
    public class UserService
    {
        private readonly GroceryAppDbContext _context;
        public UserService(GroceryAppDbContext context)
        {
            _context = context;
        }

        public List<UserModel> GetUsers(int pageIndex,int pageSize)
        {
            return _context.Users.Skip(pageIndex*pageSize).Take(pageSize).ToList();

        }
        public UserModel GetUserById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user; // will return null if not found
        }

        public void AddUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserModel user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
            
        }
    }
}
