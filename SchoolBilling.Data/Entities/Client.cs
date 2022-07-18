using System.Collections.Generic;

namespace SchoolBilling.Data.Entities
{
    public class Client: BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Invoice>? Invoices { get; set; }
    }
}
