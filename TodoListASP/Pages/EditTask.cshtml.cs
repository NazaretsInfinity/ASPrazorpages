using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TodoListASP.Models;
using TodoListASP.Repository;
using TodoListASP.Services;

namespace TodoListASP.Pages
{
    public class EditTaskModel : PageModel
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        public EditTaskModel(ITaskService taskService, ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _taskService = taskService;
        }

        [BindProperty(Name = "id", SupportsGet = true)]
        public int TaskId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Field is empty")]
        [MinLength(3, ErrorMessage = "Title must contain at least 3 characters")]
        public required string Title { get; set; }

        [BindProperty]
        [StringLength(256, ErrorMessage = "Can't contain more than 256 characters")]
        public string? Description { get; set; }


        [BindProperty]
        public bool IsDone { get; set; }

        [BindProperty]
        public DateTime CreatedAt { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            UserTask? task = _taskService.GetTaskById(TaskId);

            if (task is null) return RedirectToPage("/Index");
            task.Title= Title;
            task.Description= Description;
            task.CreatedAt= CreatedAt;
            task.IsDone= IsDone;

            _taskRepository.SaveChanges();
            return RedirectToPage("/Index");
        }


        public IActionResult OnGet()
        {
            UserTask? task = _taskService.GetTaskById(TaskId);
            if (task is null) 
                return RedirectToPage("/Index");

            Title = task.Title; 
            Description =task.Description;
            IsDone = task.IsDone;
            CreatedAt = task.CreatedAt;
            return Page();
        }
    }
}
