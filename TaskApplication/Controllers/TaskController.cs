using Microsoft.AspNetCore.Mvc;
using TaskApp.Service;

namespace TaskApplication.Controllers
{
    [ApiController]
    [Route("task/[controller]")]
    public class TaskController : ControllerBase
    {
        public TaskService inTaskService;

        public TaskController(TaskService _taskService)
        {
            inTaskService = _taskService;
        }

        [HttpGet("GetTask")]
        public IActionResult Index()
        {
            return Ok(inTaskService.GetTaskInPage(0,10));
        }
    }
}
