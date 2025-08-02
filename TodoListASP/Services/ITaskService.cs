using TodoListASP.Models;

namespace TodoListASP.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();

        void CreateTask(string name, string? description);

        UserTask? GetTaskById(int id);
        void InvertTaskStatus(int id);
    }
}
