using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class EditParentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditParentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Bind only the editable fields
        [BindProperty]
        public int ParentId { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string UserName { get; set; }

        public Parent Parent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the parent and associated user details
            Parent = await _context.Parents
                .Include(p => p.User) // Include related user data
                .FirstOrDefaultAsync(p => p.ParentId == id);

            if (Parent == null)
            {
                return NotFound("Parent not found.");
            }

            // Pre-populate the fields to be edited
            ParentId = Parent.ParentId;
            FullName = Parent.FullName;
            Email = Parent.Email;
            PhoneNumber = Parent.PhoneNumber;
            UserName = Parent.User.UserName;  // Make sure to populate UserName from the User entity

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var parentToUpdate = await _context.Parents
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.ParentId == id);

            if (parentToUpdate == null)
            {
                return NotFound();
            }

            // Update only the fields that are allowed to be edited
            parentToUpdate.FullName = FullName;
            parentToUpdate.Email = Email;
            parentToUpdate.PhoneNumber = PhoneNumber;

            // Update corresponding User fields, including UserName
            parentToUpdate.User.FullName = FullName;  // Sync with Parent
            parentToUpdate.User.Email = Email;        // Sync with Parent
            parentToUpdate.User.PhoneNumber = PhoneNumber;  // Sync with Parent
            parentToUpdate.User.UserName = UserName;  // Update the UserName field

            // Save the changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving changes: {ex.Message}");
                return Page(); // Stay on the page if saving fails
            }

            return RedirectToPage("/Parent"); // Redirect to the desired page
        }
    }
}
