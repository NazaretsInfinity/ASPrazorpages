using TodoListASP.Models;

namespace TodoListASP.Repository
{
    public interface ITaskRepository
    {
        List<UserTask> GetAll();
        UserTask? GetById(int id);
        void Create(UserTask task);
        void Delete(int id);

        void SaveChanges();
    }
}
