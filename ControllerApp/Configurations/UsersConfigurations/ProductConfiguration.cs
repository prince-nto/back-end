using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TenderSystem.Models;

namespace TenderSystem.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(p => p.Description).HasMaxLength(50).IsRequired();
            builder.Property(p => p.ProductNo).HasMaxLength(50);
            builder.Property(p => p.ProductPrice).HasConversion(v => Decimal.ToDouble(v), v => Convert.ToDecimal(v));
        }
    }
}
