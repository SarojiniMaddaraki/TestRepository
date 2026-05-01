using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApp.Infrastructure;
using TodoApp.Domain;

namespace TodoApp.Service
{
    public class TodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        // ✅ 1. Get TodoItems (Pagination)
        public List<TodoItem> GetTodosInPage(int pageIndex, int pageSize)
        {
            return _context.TodoItems
                .Skip(pageIndex)
                .Take(pageSize)
                .ToList();
        }

        // ✅ 2. Get Users (Pagination)
        public List<User> GetUsersInPage(int pageIndex, int pageSize)
        {
            return _context.Users
                .Skip(pageIndex)
                .Take(pageSize)
                .ToList();
        }
    }
}