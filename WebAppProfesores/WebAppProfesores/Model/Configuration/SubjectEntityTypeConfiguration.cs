using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppProfesores.Model.Configuration
{
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasMany(x=> x.Attendances)
                .WithOne(x=>x.Subject)
                .HasForeignKey(x=>x.SubjectId);

        }
    }
}
