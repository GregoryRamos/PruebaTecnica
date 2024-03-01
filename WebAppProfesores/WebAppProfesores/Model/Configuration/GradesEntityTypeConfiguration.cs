using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppProfesores.Model.Configuration
{
    public class GradesEntityTypeConfiguration : IEntityTypeConfiguration<Grades>
    {
        public void Configure(EntityTypeBuilder<Grades> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasOne(x=> x.Student)
                .WithMany(x=> x.Grades)
                .HasForeignKey(x=> x.StudentId);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}
