using Assignment.Data;  // Ensure you're using the correct namespace for DbContext and Teacher
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Assignment.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class EditTeacherModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditTeacherModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment.Data.Teacher Teacher { get; set; }  // Ensure you're using the correct Teacher class from Data

        public IActionResult OnGet(int id)
        {
            Teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (Teacher == null)
            {
                return RedirectToPage("./Teacher");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var teacherInDb = _context.Teachers.FirstOrDefault(t => t.TeacherId == Teacher.TeacherId);
            if (teacherInDb == null)
            {
                return RedirectToPage("./Teacher");
            }

            // Update all fields
            teacherInDb.FullName = Teacher.FullName;
            teacherInDb.Subject = Teacher.Subject;
            teacherInDb.Salary = Teacher.Salary;
            teacherInDb.JoiningDate = Teacher.JoiningDate;
            teacherInDb.TeacherDescription = Teacher.TeacherDescription;
            teacherInDb.Email = Teacher.Email;

            _context.SaveChanges();
            return RedirectToPage("./Teacher");
        }
    }
}
