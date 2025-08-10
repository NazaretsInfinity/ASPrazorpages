using TodoListASP.Models;

namespace TodoListASP.Repository.Implementations
{
    public class TaskRepository : Repository<UserTask>
    {
        protected override string GetFilePath()
        {
            return "tasks.json";
        }
    }
}
