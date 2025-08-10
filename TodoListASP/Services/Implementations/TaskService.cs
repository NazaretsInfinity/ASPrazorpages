using TodoListASP.Models;
using TodoListASP.Exceptions;
using TodoListASP.Repository;


namespace TodoListASP.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<UserTask> _taskRepository;


        public TaskService(IRepository<UserTask> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public List<UserTask> GetTasks() => _taskRepository.GetAll();

        public void CreateTask(string name, string? description)
        {
            UserTask task = new UserTask()
            {
                Title = name,
                Description = description
            };
            _taskRepository.Create(task);
        }

        public void DeleteTask(int id)
        {

#if oldbones

            //foreach (UserTask task in _tasks)   //first loop will be here!
            //    if(task.Id == id)
            //    {
            //        _tasks.Remove(task); //second loop will be here! cause programm doesn't know where task is placed exactly 
            //        break;
            //    } 


            //here we have only one loop, cause we remove via the index of element
            //we treat list as an array(because it kinda is)
            for (int i = 0; i < _tasks.Count; ++i)
            {
                UserTask task = _tasks[i];
                if (task.Id == id)
                {
                    _tasks.RemoveAt(i);
                    break; // neccessity( you modify list - it won't be same, therefore foreach loop will crush)
                }
            } 
#endif

            _taskRepository.Delete(id);
        }

        public UserTask? GetTaskById(int id) => _taskRepository.GetById(id);

        public void InvertTaskStatus(int id)
        {
            UserTask? task = GetTaskById(id);
            if (task == null)
                throw new TaskNotFoundException(id);
            task.IsDone = !task.IsDone;

            _taskRepository.SaveChanges();
        }
    }
}
