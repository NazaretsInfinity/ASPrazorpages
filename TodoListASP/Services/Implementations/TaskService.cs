using TodoListASP.Models;

namespace TodoListASP.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public List<UserTask> GetTasks()
        {
            return new List<UserTask>()
            {
                new UserTask() {Title = "Task 1", Description="First task desc"},
                new UserTask() {Title = "Task 2", Description="Second task desc"},
                new UserTask() {Title="Task 3"}
            };
        }
    }
}
