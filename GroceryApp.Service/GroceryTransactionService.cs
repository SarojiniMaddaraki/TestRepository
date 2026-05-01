using GroceryApp.DAL;
using GroceryApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryApp.Service
{
    public class GroceryTransactionService
    {
        private readonly GroceryAppDbContext _context;
        public GroceryTransactionService(GroceryAppDbContext context)
        {
            _context = context;
        }

        public List<GroceryTransactionModel> GetGroceryTransactions(int pageIndex,int pageSize)
        {
            return _context.GroceryTransactions.Skip(pageIndex).Take(pageSize).ToList();
        }
        public GroceryTransactionModel GetGroceryTransactionById(Guid id)
        {
            var groceryEntry = _context.GroceryTransactions.FirstOrDefault(x => x.Id == id);
            return groceryEntry;
        }
        public void AddGroceryTrans(GroceryTransactionModel groceryEntry)
        {
            _context.GroceryTransactions.Add(groceryEntry);
            _context.SaveChanges();
        }
        public void DeleteGroceryTrans(Guid id)
        {
            var groceryEntry = _context.GroceryTransactions.FirstOrDefault(x => x.Id == id);
            if (groceryEntry != null)
            {
                _context.GroceryTransactions.Remove(groceryEntry);
            }
            _context.SaveChanges();
        }

        public void UpdateGroceryTrans(GroceryTransactionModel groceryEntry)
        {
            _context.GroceryTransactions.Update(groceryEntry);
            _context.SaveChanges();
        }
    }
}
