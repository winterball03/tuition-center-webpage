using Assignment.Data;  // Ensure the correct namespace is used
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BCrypt.Net;

namespace Assignment.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class AddTeacherModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddTeacherModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment.Data.Teacher Teacher { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Assign the default password "teacher" and hash it using BCrypt
            var defaultPassword = "teacher";
            Teacher.PasswordHash = BCrypt.Net.BCrypt.HashPassword(defaultPassword);

            // Add the teacher to the database and save changes
            _context.Teachers.Add(Teacher);
            _context.SaveChanges();

            return RedirectToPage("./Teacher");
        }
    }
}


