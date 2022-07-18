using SchoolBilling.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolBilling.Data.Configurations
{
    public class ClientConfig: EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            this.ToTable("Client", "dbo");

            this.HasKey(s => s.Id);

            this.Property(s => s.Name).IsRequired().HasMaxLength(100);
            this.Property(s => s.IsActive).IsRequired();

            this.HasMany(s => s.Invoices).WithRequired(s => s.Client).HasForeignKey(s => s.ClientId).WillCascadeOnDelete(false);
        }
    }
}
