using Assignment.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class LinkChildModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LinkChildModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty]
        public int SelectedStudentId { get; set; } // For selecting the student

        // Change from List<User> to List<Student>
        public List<Student> Students { get; set; }  // List of students

        public async Task<IActionResult> OnGetAsync()
        {
            // Query directly from the Students table based on the search term
            var query = _context.Students.AsQueryable();  // Only query Students

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                // Filter the students by FullName or Email in the Students table
                query = query.Where(s => s.FullName.Contains(SearchTerm) || s.Email.Contains(SearchTerm));
            }

            Students = await query.ToListAsync();  // Return list of Students only
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Find the logged-in parent based on email or user identity
            var parentEmail = User.Identity.Name;  // This retrieves the logged-in user's email
            var parent = await _context.Parents.FirstOrDefaultAsync(p => p.Email == parentEmail);

            if (parent == null)
            {
                // If parent not found, display error
                ModelState.AddModelError(string.Empty, $"Parent not found with email: {parentEmail}");
                return Page();
            }

            // Ensure you're linking the correct student based on StudentId
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == SelectedStudentId);

            if (student == null)
            {
                // If student not found, display error
                ModelState.AddModelError(string.Empty, "Student not found.");
                return Page();
            }

            // Add new ParentChild entry using StudentId and ParentId
            var parentChild = new ParentChild
            {
                ParentId = parent.ParentId,
                StudentId = student.StudentId
            };

            try
            {
                _context.ParentChildren.Add(parentChild);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or display the error
                ModelState.AddModelError(string.Empty, $"Error saving to database: {ex.Message}");
                return Page();
            }

            return RedirectToPage("/Child");
        }
    }
}
