using TodoListASP.Models;

namespace TodoListASP.Repository
{
    public interface IRepository<T> where T : Entity // where T : (class) - means T must be inherited from (class) 
    {
        List<T> GetAll();
        T? GetById(int id);
        void Create(T task);
        void Delete(int id);

        void SaveChanges();
    }
}
