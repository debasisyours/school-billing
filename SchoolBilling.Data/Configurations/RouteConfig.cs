using SchoolBilling.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolBilling.Data.Configurations
{
    public class RouteConfig: EntityTypeConfiguration<Route>
    {
        public RouteConfig()
        {
            this.ToTable("Route", "dbo");

            this.HasKey(s => s.Id);

            this.Property(s => s.Name).IsRequired().HasMaxLength(100);

            this.HasMany(s => s.Invoices).WithRequired(s => s.Route).HasForeignKey(s => s.RouteId).WillCascadeOnDelete(false);
        }
    }
}
