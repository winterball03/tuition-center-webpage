using Assignment.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using System;
using System.Linq;

namespace Assignment.Pages
{
    public class Admin_HomepageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Admin_HomepageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties for course statistics
        public int TotalCourses { get; set; }
        public decimal AverageTuitionFees { get; set; }

        // Properties for teacher statistics
        public int TotalTeachers { get; set; }
        public decimal AverageTeacherSalary { get; set; }

        // Properties for student statistics
        public int TotalStudents { get; set; }

        // Properties for parent statistics
        public int TotalParents { get; set; }

        public void OnGet()
        {
            // Calculate course statistics
            TotalCourses = _context.Courses.Count();
            AverageTuitionFees = _context.Courses.Any() ? _context.Courses.Average(c => c.TuitionFees) : 0;

            // Calculate teacher statistics
            TotalTeachers = _context.Teachers.Count();
            AverageTeacherSalary = _context.Teachers.Any() ? _context.Teachers.Average(t => t.Salary) : 0;

            // Calculate student statistics
            TotalStudents = _context.Users.Count(u => u.Role == "Student");

            // Calculate parent statistics
            TotalParents = _context.Users.Count(u => u.Role == "Parent");

           
        }
    }
}
