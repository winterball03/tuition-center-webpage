using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BCrypt.Net;
using System.Threading.Tasks;

namespace Assignment.Pages
{
    public class AddParentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddParentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties to capture parent information
        [BindProperty]
        public string FullName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);

            // Create a new User (Parent)
            var user = new User
            {
                UserName = Username,
                Email = Email,
                PhoneNumber = PhoneNumber,
                PasswordHash = hashedPassword,
                FullName = FullName, // Ensure FullName is saved
                Role = "Parent" // Assign Parent role
            };

            // Save the User to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();  // Save User first to generate UserId

            // Create the Parent entry and link it to the User
            var parent = new Parent
            {
                FullName = FullName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                UserId = user.Id  // Link Parent to User
            };

            // Save the Parent to the database
            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();  // Save Parent entry

            // Redirect to Parent list page
            return RedirectToPage("/Parent");
        }
    }
}
