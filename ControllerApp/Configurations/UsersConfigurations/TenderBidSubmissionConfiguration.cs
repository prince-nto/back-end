using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TenderSystem.Models;


namespace TenderSystem.Configurations
{
    public class TenderBidSubmissionConfiguration : IEntityTypeConfiguration<TenderBidSubmission>
    {
        public void Configure(EntityTypeBuilder<TenderBidSubmission> builder)
        {
            builder.ToTable("TenderBidSubmissions");

            builder.Property(p => p.TotalQuotation).IsRequired().HasConversion(v => Decimal.ToDouble(v), v => Convert.ToDecimal(v));
            builder.HasOne(p => p.SumittedBy).WithMany().HasForeignKey(p => p.SumittedById);
            builder.HasOne(p => p.Tender).WithMany().HasForeignKey(p => p.TenderId);
        }
    }
}
