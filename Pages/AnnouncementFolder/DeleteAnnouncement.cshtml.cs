using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Assignment.Pages.AnnouncementFolder
{
    public class DeleteAnnouncementModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteAnnouncementModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Announcement Announcement { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Announcement = await _context.Announcements.FindAsync(id);

            if (Announcement == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Ensure the AnnouncementId is set before attempting to delete
            if (Announcement == null || Announcement.AnnouncementId == 0)
            {
                return NotFound();
            }

            // Find the announcement by its ID before deleting
            var announcementToDelete = await _context.Announcements.FindAsync(Announcement.AnnouncementId);

            if (announcementToDelete == null)
            {
                return NotFound();
            }

            _context.Announcements.Remove(announcementToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("AnnouncementDetails");
        }
    }
}
