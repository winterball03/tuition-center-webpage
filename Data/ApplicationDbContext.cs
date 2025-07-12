using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Users
        public DbSet<User> Users { get; set; }

        // DbSet for Courses
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentChild> ParentChildren { get; set; } // Add this
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TuitionClass> TuitionClasses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Comment> Comments { get; set; }  // Add this line for the comments

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student foreign key relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithMany()  // Assuming User does not need a collection of Students
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete when User is deleted

            // Configure Parent foreign key relationship
            modelBuilder.Entity<Parent>()
                .HasOne(p => p.User)
                .WithMany()  // Assuming User does not need a collection of Parents
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParentChild>()
                .HasKey(pc => pc.Id);

            modelBuilder.Entity<ParentChild>()
                .HasOne(pc => pc.Parent)
                .WithMany()
                .HasForeignKey(pc => pc.ParentId)
                .HasPrincipalKey(p => p.Id) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParentChild>()
                .HasOne(pc => pc.Student)
                .WithMany()
                .HasForeignKey(pc => pc.StudentId)
                .HasPrincipalKey(s => s.Id) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => sc.StudentCourseId);

            // Define the many-to-many relationship between Student and Course
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasColumnType("decimal(18,2)");  // Set precision to 18 digits, 2 of them after the decimal point

            modelBuilder.Entity<Payment>()
                .Property(p => p.TotalFees)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Course>()
                .Property(c => c.TuitionFees)
                .HasColumnType("decimal(18,2)");  // Precision: 18, Scale: 2

            // Define the many-to-many relationship between Teacher (User) and Course
            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Teacher)   // Each TeacherCourse has one Teacher (User)
                .WithMany()                 // A teacher can have many courses they teach
                .HasForeignKey(tc => tc.TeacherId)
                .OnDelete(DeleteBehavior.Cascade); // Delete TeacherCourse if Teacher is deleted

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Course)    // Each TeacherCourse has one Course
                .WithMany()                 // A course can have many teachers teaching it
                .HasForeignKey(tc => tc.CourseId)
                .OnDelete(DeleteBehavior.Cascade); // Delete TeacherCourse if Course is deleted
        
        }
    }

    

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseCode { get; set; }

        public string CourseDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TuitionFees { get; set; }

        [Required]
        public TimeSpan TuitionTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property for the many-to-many relationship, make it optional
        public List<StudentCourse>? StudentCourses { get; set; }

        // Navigation property for TuitionClass, make it optional
        public TuitionClass? TuitionClass { get; set; }
    }


    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public string TeacherDescription { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class Announcement
    {
        public int AnnouncementId { get; set; } // Primary key

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now; // Date of creation
    }

    public class Student
    {
        public int StudentId { get; set; }  // Auto-increment primary key
        public string FullName { get; set; }
        public string Email { get; set; }

        // Foreign key to the User table
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property

        // Navigation property for the many-to-many relationship
        public List<StudentCourse> StudentCourses { get; set; }  // Add this
    }
    public class Parent
    {
        public int ParentId { get; set; }   // Primary key for Parent
        public string FullName { get; set; } // Full name of the parent
        public string Email { get; set; }    // Email address of the parent
        public string PhoneNumber { get; set; } // Phone number of the parent

        // Foreign key to the User table
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property to User
    }


    public class StudentCourse
    {
        public int StudentCourseId { get; set; } // Primary key

        // Foreign key to Student
        public int StudentId { get; set; }
        public Student Student { get; set; }  // Navigation property

        // Foreign key to Course
        public int CourseId { get; set; }
        public Course Course { get; set; }  // Navigation property
    }

    public class ParentChild
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int StudentId { get; set; }

        public User Parent { get; set; }
        public User Student { get; set; }
    }

    public class Payment
    {
        public int PaymentId { get; set; }  // Primary key
        public int ParentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal TotalFees { get; set; }
        public DateTime PaymentDate { get; set; }

        // Navigation properties
        public Parent Parent { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

    public class TuitionClass
    {
        public int TuitionClassId { get; set; }
        public string ClassName { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public TimeSpan Time { get; set; }

        // Navigation property for the many-to-many relationship
        public List<StudentCourse> StudentCourses { get; set; }
        // Foreign key for Course
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Comment> Comments { get; set; }  // One-to-many relationship
    }

    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        public User Teacher { get; set; }
        public Course Course { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }       // Primary key

        public int TuitionClassId { get; set; }  // Foreign key to the TuitionClass
        public string UserId { get; set; }       // ID of the user who posted the comment
        public string Text { get; set; }         // The comment text
        public DateTime PostedDate { get; set; } // Date when the comment was posted

        // Navigation property for the TuitionClass
        public TuitionClass TuitionClass { get; set; }
    }
}
