using TaskApp.DAL;
using TaskApp.Model;

namespace TaskApp.Service
{
    public class TaskService
    {
        public readonly TaskApplicationContext instanceTaskApplicationContext;

        public TaskService(TaskApplicationContext _context)
        {
            instanceTaskApplicationContext = _context;
        }
        public List<TaskModel> GetTaskInPage(int pageIndex,int pageSize)
        {
            var tasks = new List<TaskModel>();
            tasks = instanceTaskApplicationContext.Tasks.Skip(pageIndex).Take(pageSize).ToList();
            return tasks;
        }
    }
}
