using Assignment.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class ChildModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ChildModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Student> Children { get; set; } = new List<Student>();

        public async Task<IActionResult> OnGetAsync()
        {
            // Get the logged-in parent by their email
            var parentEmail = User.Identity.Name;
            var parent = await _context.Parents.FirstOrDefaultAsync(p => p.Email == parentEmail);

            if (parent == null)
            {
                ViewData["ErrorMessage"] = "Parent not found.";
                return Page();
            }

            // Get the list of children linked to this parent
            var parentChildren = await _context.ParentChildren
                .Where(pc => pc.ParentId == parent.ParentId)
                .Select(pc => pc.StudentId)
                .ToListAsync();

            if (parentChildren.Any())
            {
                // Fetch the children details based on their StudentId
                Children = await _context.Students
                    .Where(s => parentChildren.Contains(s.StudentId))
                    .ToListAsync();
            }

            if (!Children.Any())
            {
                ViewData["ErrorMessage"] = "No children linked to the parent.";
            }

            return Page();
        }
    }
}
