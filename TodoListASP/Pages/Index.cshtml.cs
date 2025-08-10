using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TodoListASP.Exceptions;
using TodoListASP.Services;

namespace TodoListASP.Pages
{
    public class IndexModel : PageModel
    {
    
        private readonly ITaskService _taskService;
        public IndexModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public bool ShowNewTaskForm { get; set; }

        [BindProperty(Name = "Error", SupportsGet = true)]
        public string? ErrorMessage { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Field is empty")]
        [MinLength(3, ErrorMessage ="Title must contain at least 3 characters")]
        public required string Title { get; set; }

        [BindProperty]
        [StringLength(256,ErrorMessage ="Can't contain more than 256 characters")]

        public string? Description { get; set; }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                ShowNewTaskForm = false;
                return Page();
                //Page() - display current page 
            }

            _taskService.CreateTask(Title, Description);

            return RedirectToPage("/Index"); //leavin post query context
        }

        public IActionResult OnGetChangeTaskStatus(int taskId)
        {
            try
            {
                _taskService.InvertTaskStatus(taskId);
            }
            catch(TaskNotFoundException)
            {
            return RedirectToPage("/Index", new {error = "Couldn't find task"});
            }
            
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetDeleteTask(int taskId)
        {
            _taskService.DeleteTask(taskId);
            return RedirectToPage("/Index");
        }
    }
}
