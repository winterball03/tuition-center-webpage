using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Pages.AnnouncementFolder
{
    public class EditAnnouncementModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditAnnouncementModel(ApplicationDbContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure that AnnouncementId is set properly
            if (Announcement.AnnouncementId == 0)
            {
                return BadRequest("Invalid Announcement ID.");
            }

            _context.Attach(Announcement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(Announcement.AnnouncementId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("AnnouncementDetails");
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.AnnouncementId == id);
        }
    }
}
