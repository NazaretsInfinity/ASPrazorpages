using TodoListASP.Models;
using TodoListASP.Exceptions;


namespace TodoListASP.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks;

        private int _nextTaskId;

        public TaskService()
        {
            _tasks = new List<UserTask>();
            _nextTaskId = 1;
        }
        public List<UserTask> GetTasks() => _tasks;

        public void CreateTask(string name, string? description)
        {
            UserTask task = new UserTask()
            {
                Id = _nextTaskId++,
                Title = name,
                Description = description
            };
            _tasks.Add(task);
        }

        public void DeleteTask(int id)
        {

            #region foreach problema
            //foreach (UserTask task in _tasks)   //first loop will be here!
            //    if(task.Id == id)
            //    {
            //        _tasks.Remove(task); //second loop will be here! cause programm doesn't know where task is placed exactly 
            //        break;
            //    } 


            #endregion

            //here we have only one loop, cause we remove via the index of element
            //we treat list as an array(because it kinda is)
            for(int i = 0; i < _tasks.Count; ++i)
            {
                UserTask task = _tasks[i];
                if(task.Id == id)
                {
                    _tasks.RemoveAt(i);
                    break; // neccessity( you modify list - it won't be same, therefore foreach loop will crush)
                }
            }
        }

        public UserTask? GetTaskById(int id)
        {
            foreach (var task in _tasks)
            {
                if (task.Id == id) return task;
            }
            return null;
        }

        public void InvertTaskStatus(int id)
        {
            UserTask? task = GetTaskById(id);
            if (task == null)
                throw new TaskNotFoundException(id);
            task.IsDone = !task.IsDone;
        }
    }
}
