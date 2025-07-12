using Assignment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Assignment.Data.Course> FeaturedCourses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Facility> Facilities { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Query the top 3 courses (or any criteria for featured courses)
            FeaturedCourses = _context.Courses
                .OrderBy(c => c.CreatedAt)  // Example sorting by creation date
                .Take(3)                    // Display top 3 courses
                .ToList();

            // Fetch teachers and facilities
            Teachers = GetTeachersFromDb(); // Fetch teachers from the database
            Facilities = GetFacilities();
        }

        // Method to fetch teachers dynamically from the database
        private List<Teacher> GetTeachersFromDb()
        {
            return _context.Teachers
                .OrderBy(t => t.FullName)  // Order by name
                .Take(3)               // Display top 3 teachers (you can adjust this limit)
                .ToList();
        }

        private List<Facility> GetFacilities()
        {
            return new List<Facility>
            {
                new Facility { Name = "Library", Description = "Stocked with the latest academic resources." },
                new Facility { Name = "Science Lab", Description = "State-of-the-art laboratory facilities." },
                new Facility { Name = "Study Rooms", Description = "Quiet and comfortable study rooms." }
            };
        }
    }

    public class Facility
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
