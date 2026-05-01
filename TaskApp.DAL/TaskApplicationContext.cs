using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.Model;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.DAL
{
    public class TaskApplicationContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(local)\\SQLEXPRESS;Database=TaskToDo;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        //public TaskApplicationContext()
        //{

        //}

        public TaskApplicationContext(DbContextOptions<TaskApplicationContext>options) : base(options)
        {

        }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users{ get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

    }
}
