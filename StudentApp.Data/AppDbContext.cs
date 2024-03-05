using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Entities;

namespace StudentApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }
        public DbSet<ExamEntity> Exams { get; set; }
        public DbSet<StudentExamMarkEntity> StudentExamMarks { get; set; }

    }
}
