using Microsoft.EntityFrameworkCore;

namespace WebAppProfesores.Model
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendace> Attendaces { get; set; }

    }
}
