using Assignment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class AddCourseModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddCourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment.Data.Course Course { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Remove validation for fields not populated in the form
            ModelState.Remove("Course.TuitionClass");
            ModelState.Remove("Course.StudentCourses");

            _context.Courses.Add(Course);
            _context.SaveChanges();

            return RedirectToPage("./Course");
        }



    }
}