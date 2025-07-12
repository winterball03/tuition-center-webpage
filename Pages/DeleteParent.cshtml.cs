using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class DeleteParentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteParentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Parent Parent { get; set; }

        // Fetch the parent and related user for confirmation
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the parent and associated user details
            Parent = await _context.Parents
                .Include(p => p.User) // Include related user data
                .FirstOrDefaultAsync(m => m.ParentId == id);

            if (Parent == null)
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

            var parentToDelete = await _context.Parents
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.ParentId == id);

            if (parentToDelete == null)
            {
                return NotFound();
            }

            // Remove the parent
            _context.Parents.Remove(parentToDelete);

            // Remove the associated user as well
            _context.Users.Remove(parentToDelete.User);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the parent list page after deletion
            return RedirectToPage("/Parent");  // Make sure ParentList page exists
        }
    }
}
