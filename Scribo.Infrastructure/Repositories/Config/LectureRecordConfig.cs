using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scribo.Core.Models;

namespace Scribo.Infrastructure.Repositories.Config
{
    public class LectureRecordConfig : IEntityTypeConfiguration<LectureRecord>
    {
        public void Configure(EntityTypeBuilder<LectureRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CourseName)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.FormattedNotes)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasMaxLength(50)
                .IsRequired(false);
        }
    }
}
