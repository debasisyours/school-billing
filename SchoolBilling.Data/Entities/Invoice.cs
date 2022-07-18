using System;

namespace SchoolBilling.Data.Entities
{
    public class Invoice: BaseEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RouteCost { get; set; }
        public decimal AidCost { get; set; }
        public decimal Perdiem { get; set; }
        public int DayCount { get; set; }
        public decimal TotalCost { get; set; }
        public int CovidDayCount { get; set; }
        public string? Notes { get; set; }
        public int InvoiceNumber { get; set; }
    }
}
