using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppProfesores.Model.Configuration
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Attendances)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
