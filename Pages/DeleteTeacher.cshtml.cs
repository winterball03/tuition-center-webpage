using Assignment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Assignment.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteTeacherModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteTeacherModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment.Data.Teacher Teacher { get; set; }  // Ensure the correct Teacher class is used here

        public IActionResult OnGet(int id)
        {
            // Ensure we are working with the correct Teacher class
            Teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (Teacher == null)
            {
                return RedirectToPage("./Teacher");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            // Use the correct Teacher class
            var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return RedirectToPage("./Teacher");
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToPage("./Teacher");
        }
    }
}
