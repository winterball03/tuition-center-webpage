using Assignment.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Pages.AnnouncementFolder
{
    public class AnnouncementDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Announcement> Announcements { get; set; } = new List<Announcement>();

        public async Task OnGetAsync()
        {
            Announcements = await _context.Announcements.ToListAsync();
        }
    }
}
