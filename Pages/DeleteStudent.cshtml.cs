using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class DeleteStudentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        // Fetch the student and related user for confirmation
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the student and associated user details
            Student = await _context.Students
                .Include(s => s.User) // Include related user data
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handle the deletion
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToDelete = await _context.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (studentToDelete == null)
            {
                return NotFound();
            }

            // Remove the student
            _context.Students.Remove(studentToDelete);

            // Remove the associated user as well
            _context.Users.Remove(studentToDelete.User);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the student list page after deletion
            return RedirectToPage("Student");
        }
    }
}

