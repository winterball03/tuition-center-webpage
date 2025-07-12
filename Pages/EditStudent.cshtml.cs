using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class EditStudentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Bind only the editable fields
        [BindProperty]
        public int StudentId { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }  // New field for editing phone number

        public Student Student { get; set; }

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
                return NotFound("Student not found.");
            }

            // Pre-populate the fields to be edited
            StudentId = Student.StudentId;
            FullName = Student.FullName;
            Email = Student.Email;
            UserName = Student.User.UserName;
            PhoneNumber = Student.User.PhoneNumber;  // Pre-populate phone number

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            // Update only the fields that are allowed to be edited
            studentToUpdate.FullName = FullName;
            studentToUpdate.Email = Email;
            studentToUpdate.User.UserName = UserName;
            studentToUpdate.User.PhoneNumber = PhoneNumber;  // Update phone number

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("/Student");
        }
    }
}
