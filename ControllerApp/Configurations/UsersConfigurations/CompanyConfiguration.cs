

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenderSystem.Models;

namespace TenderSystem.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder) 
        {
            builder.ToTable("Companies");

            builder.Property(p => p.CompanyId).UseIdentityColumn();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.VatNo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Registration).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PhysicalAddress1).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PhysicalAddress2).HasMaxLength(50);
            builder.Property(p => p.Suburb).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Province).HasMaxLength(50);
            builder.Property(p => p.PostalCode).HasMaxLength(50).IsRequired();
        }
    }
}
