using System.Collections.Generic;

namespace SchoolBilling.Data.Entities
{
    public class Route: BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal RouteCost { get; set; }
        public decimal AidCost { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Invoice>? Invoices { get; set; }
    }
}
