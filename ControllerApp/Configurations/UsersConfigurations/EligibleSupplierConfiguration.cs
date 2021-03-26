using ControllerApp.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TenderSystem.Models;


namespace ControllerApp.Configurations.UsersConfigurations
{
    public class EligibleSupplierConfiguration : IEntityTypeConfiguration<EligibleSupplier>
    {
        public void Configure(EntityTypeBuilder<EligibleSupplier> builder)
        {
            builder.ToTable("EligibleSuppliers");

            builder.Property(p => p.EligibleSupplierId).ValueGeneratedOnAdd();
            builder.HasOne(p => p.Tender).WithMany().HasForeignKey(p => p.TenderId);
            builder.Property(p => p.CompanyName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.RegistrationNumber).HasMaxLength(50).IsRequired();
        }
    }
}
