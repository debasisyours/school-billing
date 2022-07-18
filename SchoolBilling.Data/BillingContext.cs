using SchoolBilling.Data.Configurations;
using SchoolBilling.Data.Entities;
using System;
using System.Data.Entity;

namespace SchoolBilling.Data
{
    /// <summary>
    /// DbContext class that defines the database structure for Billing database
    /// </summary>
    public class BillingContext: DbContext
    {
        public BillingContext(): base("name=Default")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CompanyConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new RouteConfig());
            modelBuilder.Configurations.Add(new InvoiceConfig());
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Route>? Routes { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
    }
}
