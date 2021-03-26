using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TenderSystem.Models;

namespace TenderSystem.Configurations
{
    public class TenderBidSubmissionProductConfiguration : IEntityTypeConfiguration<TenderBidSubmissionProduct>
    {
        public void Configure(EntityTypeBuilder<TenderBidSubmissionProduct> builder)
        {
            builder.ToTable("TenderBidSubmissionProducts");

            builder.Property(p => p.QuotedPrice).IsRequired().HasConversion(v => Decimal.ToDouble(v), v => Convert.ToDecimal(v));
            builder.Property(p => p.RecommendedPrice).IsRequired().HasConversion(v => Decimal.ToDouble(v), v => Convert.ToDecimal(v));
            builder.Property(p => p.Quantity).IsRequired();

           
        }
    }
}
