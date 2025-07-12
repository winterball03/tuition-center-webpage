using Assignment.Data; // Correct namespace for your DbContext
using global::Assignment.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public class TuitionClassService
    {
        private readonly ApplicationDbContext _context;

        public TuitionClassService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to generate tuition classes based on existing courses
        public async Task GenerateTuitionClassesAsync()
        {
            var courses = await _context.Courses.ToListAsync();

            foreach (var course in courses)
            {
                if (!_context.TuitionClasses.Any(tc => tc.CourseId == course.CourseId))
                {
                    var tuitionClass = new TuitionClass
                    {
                        ClassName = $"{course.CourseName} Class",
                        Subject = course.CourseName,
                        Teacher = "Default Teacher", // You can customize this
                        Time = course.TuitionTime,
                        CourseId = course.CourseId
                    };

                    _context.TuitionClasses.Add(tuitionClass);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
