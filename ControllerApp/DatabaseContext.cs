using ControllerApp.Configurations.UsersConfigurations;
using ControllerApp.DatabaseRules.Users;
using ControllerApp.Domains;
using ControllerApp.Domains.Users;
using Microsoft.EntityFrameworkCore;
using TenderSystem.Configurations;
using TenderSystem.Models;

namespace ControllerApp
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<TenderBidSubmission> TenderBidSubmissions { get; set; }
        public DbSet<TenderBidSubmissionProduct> TenderBidSubmissionProducts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StateOrgan> StateOrgans { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<EligibleSupplier> EligibleSuppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StateOrganConfiguration());
            modelBuilder.ApplyConfiguration(new TenderBidSubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new TenderBidSubmissionProductConfiguration());
            modelBuilder.ApplyConfiguration(new TenderBidSubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new EligibleSupplierConfiguration());
        }
    }
}
