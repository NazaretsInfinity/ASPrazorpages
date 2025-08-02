namespace TodoListASP.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public int TaskId { get; private set; } 
        public TaskNotFoundException(int taskid) : base($"Task with id {taskid} not found") 
        {
            TaskId = taskid;
        }
    }
}
