using Assignment.Data;
namespace Assignment.Models
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public int StudentCount { get; set; }

        public TuitionClass TuitionClass => Course?.TuitionClass;  // Access TuitionClass via Course
    }
}
