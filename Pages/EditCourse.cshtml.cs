using Assignment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Assignment.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class EditCourseModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditCourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment.Data.Course Course { get; set; }

        public IActionResult OnGet(int id)
        {
            Course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (Course == null)
            {
                return RedirectToPage("./Course");
            }
            return Page();
        }


        public IActionResult OnPost()
        {
            // Debugging: Output course ID
            Console.WriteLine("Course ID: " + Course.CourseId);

            // Debugging: Output other course information
            Console.WriteLine("Course Name: " + Course.CourseName);
            Console.WriteLine("Tuition Fees: " + Course.TuitionFees);

            // Remove validation for fields not in the form
            ModelState.Remove("Course.TuitionClass");
            ModelState.Remove("Course.StudentCourses");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Retrieve the course from the database
            var courseInDb = _context.Courses.FirstOrDefault(c => c.CourseId == Course.CourseId);
            if (courseInDb == null)
            {
                return RedirectToPage("./Course");
            }

            // Update fields
            courseInDb.CourseName = Course.CourseName;
            courseInDb.CourseCode = Course.CourseCode;
            courseInDb.CourseDescription = Course.CourseDescription;
            courseInDb.TuitionFees = Course.TuitionFees;
            courseInDb.TuitionTime = Course.TuitionTime;

            try
            {
                // Force EF to mark the entity as modified
                _context.Attach(courseInDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                // Save changes to the database
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error saving changes: " + ex.Message);
                return Page();
            }

            return RedirectToPage("./Course");
        }


    }
}
