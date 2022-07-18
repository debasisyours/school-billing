using SchoolBilling.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolBilling.Data.Configurations
{
    public class CompanyConfig: EntityTypeConfiguration<Company>
    {
        public CompanyConfig()
        {
            this.ToTable("Company", "dbo");

            this.HasKey(s => s.Id);
            this.Property(s => s.Address).IsRequired().HasMaxLength(500);
            this.Property(s => s.Fax).HasMaxLength(100);
            this.Property(s => s.City).HasMaxLength(100);
            this.Property(s => s.ContactEmail).HasMaxLength(200);
            this.Property(s => s.State).HasMaxLength(100);
            this.Property(s => s.CountyName).HasMaxLength(200);
            this.Property(s => s.ContactInformation).HasMaxLength(200);
            this.Property(s => s.ContactPerson).HasMaxLength(200);
            this.Property(s => s.Country).HasMaxLength(100);
            this.Property(s => s.Name).HasMaxLength(200);
            this.Property(s => s.Phone).HasMaxLength(200);
            this.Property(s => s.PostalCode).HasMaxLength(10);
        }
    }
}
