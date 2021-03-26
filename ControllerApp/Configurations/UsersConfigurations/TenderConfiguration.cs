using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenderSystem.Models;

namespace TenderSystem.Configurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.ToTable("Tenders");

            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();
            builder.Property(p => p.EmailAddress).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BidNo).HasMaxLength(20);
            builder.Property(p => p.ContactNo).HasMaxLength(50).IsRequired();
            builder.HasOne(p => p.StateOrgan).WithMany().HasForeignKey(p => p.StateOrganId);
        }
    }
}
