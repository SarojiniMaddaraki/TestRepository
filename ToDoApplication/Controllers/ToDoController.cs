using Microsoft.AspNetCore.Mvc;
using TodoApp.Service;

namespace ToDoApplication.Controllers
{
    [ApiController]
    [Route("todoApp/[controller]")]
    public class ToDoController : ControllerBase
    {
        public TodoService inToDoService;

        public ToDoController(TodoService _toDoService)
        {
            inToDoService = _toDoService;
        }

        // ✅ 1. Get Todos
        [HttpGet("GetTodos")]
        public IActionResult GetTodos()
        {
            return Ok(inToDoService.GetTodosInPage(0, 5));
        }

        // ✅ 2. Get Users
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(inToDoService.GetUsersInPage(0, 5));
        }
    }
}