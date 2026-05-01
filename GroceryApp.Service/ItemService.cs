using GroceryApp.DAL;
using GroceryApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryApp.Service
{
    public class ItemService
    {
        private readonly GroceryAppDbContext _context;
        public ItemService(GroceryAppDbContext context)
        {
            _context = context;
        }

        public List<ItemModel> GetItems(int pageIndex,int pageSize)
        {
            return _context.Items.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public ItemModel GetItemById(Guid id)
        {
            var item=_context.Items.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public void AddItem(ItemModel item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public void UpdateItem(ItemModel item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        
    }
}
