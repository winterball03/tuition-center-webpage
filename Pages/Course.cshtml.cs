using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Assignment.Data.Course> Courses { get; set; } = new List<Assignment.Data.Course>();

        [BindProperty]
        public int? SelectedCourseId { get; set; } // Holds the selected course ID

        public void OnGet()
        {
            // Retrieve the list of courses
            Courses = _context.Courses.ToList();
        }

        // Handle course registration for parents
        public IActionResult OnPostRegisterChild()
        {
            if (SelectedCourseId.HasValue)
            {
                // Redirect to the RegisterChild page with the selected course ID
                return RedirectToPage("/RegisterChild", new { courseId = SelectedCourseId.Value });
            }

            // If no course is selected, return to the page with an error
            ModelState.AddModelError(string.Empty, "No course selected.");
            return Page();
        }

        // Handle the selection of a course by a teacher
        public IActionResult OnPostSelectCourseToTeach()
        {
            if (SelectedCourseId.HasValue)
            {
                // Redirect to the TeacherCourseConfirmation page with the selected course ID
                return RedirectToPage("/TeacherCourseConfirmation", new { courseId = SelectedCourseId.Value });
            }

            ModelState.AddModelError(string.Empty, "No course selected.");
            return Page();
        }
    }
}
