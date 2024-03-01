using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppProfesores.Model.Configuration
{
    public class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.Student)
                .WithMany(x=>x.Attendances)
                .HasForeignKey(x=>x.StudentId);

            builder.HasOne(x=> x.Subject)
                .WithMany(x=> x.Attendances)
                .HasForeignKey(x=>x.SubjectId);
        }
    }
}
