using TodoListASP.Models;

namespace TodoListASP.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();
    }
}
