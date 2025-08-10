using System.Text.Json;
using TodoListASP.Models;

namespace TodoListASP.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private const string FILE_PATH = "tasks.json";
        private readonly List<UserTask> _tasks;
        private int _nextId;

        public TaskRepository()
        {
            try
            {
                string json = File.ReadAllText(FILE_PATH);
                //null, cause fight might not exist 
                List<UserTask>? tasks = JsonSerializer.Deserialize<List<UserTask>>(json);

                if (tasks == null)
                    throw new InvalidDataException("Failed to deserialize tasks from json"); // we go to catch part then
                _tasks = tasks;
            }
            catch (Exception)
            {
                _tasks = new List<UserTask>();
            }

            int maxId = 0;
            foreach (var task in _tasks)
            {
                if(task.Id > maxId) maxId = task.Id;
            }

            _nextId = maxId+1;
        }
        public void Create(UserTask task)
        {
          task.Id = _nextId++;
            _tasks.Add(task);
            SaveChanges();
        }

        public void Delete(int id)
        {
            UserTask task;
            for(int i =0; i < _tasks.Count; ++i)
            {
                task = _tasks[i];
                if (task.Id == id)
                {
                    _tasks.RemoveAt(i);
                    break;
                }
            }

            SaveChanges();
        }

        public List<UserTask> GetAll() => _tasks;

        public UserTask? GetById(int id)
        {
            foreach (var task in _tasks)
            {
                if (task.Id == id) return task;
            }
            return null;
        }

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_tasks);
            File.WriteAllText(FILE_PATH, json);
        }
    }
}
