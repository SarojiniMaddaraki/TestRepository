using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GroceryApp.Model;

namespace GroceryApp.DAL
{
    public class GroceryAppDbContext:DbContext
    {
        public GroceryAppDbContext(DbContextOptions<GroceryAppDbContext> options) : base(options)
        {

        }

        

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<GroceryTransactionModel> GroceryTransactions { get; set; }
    }
}
