using System.Collections.Generic;

namespace SchoolBilling.Data.Entities
{
    public class Company: BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? CountyName { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactInformation { get; set; }
        public string? ContactEmail { get; set; }
        public int StartingInvoiceNumber { get; set; }
        public virtual List<Invoice>? Invoices { get; set; }
    }
}
