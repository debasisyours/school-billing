using SchoolBilling.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolBilling.Data.Configurations
{
    public class InvoiceConfig: EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfig()
        {
            this.ToTable("Invoice", "dbo");

            this.HasKey(s => s.Id);

            this.Property(s => s.Notes).HasMaxLength(500);
        }
    }
}
