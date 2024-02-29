using Microsoft.EntityFrameworkCore;
using WebAppProfesores.Model.Configuration;

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
        public DbSet<Attendance> Attendaces { get; set; }

        public IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectEntityTypeConfiguration());

            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Lengua Española",
                    Description= "n/a"
                }, 
                new Subject
                {
                    Id = 2,
                    Name = "Matemáticas",
                    Description = "n/a"
                },
                new Subject
                {
                    Id = 3,
                    Name = "Ciencias Sociales",
                    Description = "n/a"
                },
                new Subject
                {
                    Id = 4,
                    Name = "Ciencias Naturales",
                    Description = "n/a"
                });
        }


    }



}
