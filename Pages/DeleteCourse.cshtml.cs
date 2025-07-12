using Assignment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Assignment.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteCourseModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteCourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment.Data.Course Course { get; set; }  // Ensure it uses the correct Course class

        public IActionResult OnGet(int id)
        {
            Course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (Course == null)
            {
                return RedirectToPage("./Course");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return RedirectToPage("./Course");
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToPage("./Course");
        }
    }
}