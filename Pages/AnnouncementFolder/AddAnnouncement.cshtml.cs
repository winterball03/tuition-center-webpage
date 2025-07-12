using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Assignment.Pages.AnnouncementFolder
{
    public class AddAnnouncementModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddAnnouncementModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Announcement Announcement { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add the announcement to the database
            _context.Announcements.Add(Announcement);
            await _context.SaveChangesAsync();

            return RedirectToPage("AnnouncementDetails");
        }
    }
}
