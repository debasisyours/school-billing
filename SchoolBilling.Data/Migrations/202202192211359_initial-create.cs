namespace SchoolBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RouteCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AidCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Perdiem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DayCount = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CovidDayCount = c.Int(nullable: false),
                        Notes = c.String(maxLength: 500),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Route", t => t.RouteId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.ClientId)
                .Index(t => t.RouteId)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        RouteCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AidCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 500),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 200),
                        Fax = c.String(maxLength: 100),
                        CountyName = c.String(maxLength: 200),
                        ContactPerson = c.String(maxLength: 200),
                        ContactInformation = c.String(maxLength: 200),
                        ContactEmail = c.String(maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Invoice", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Invoice", "RouteId", "dbo.Route");
            DropIndex("dbo.Invoice", new[] { "Company_Id" });
            DropIndex("dbo.Invoice", new[] { "RouteId" });
            DropIndex("dbo.Invoice", new[] { "ClientId" });
            DropTable("dbo.Company");
            DropTable("dbo.Route");
            DropTable("dbo.Invoice");
            DropTable("dbo.Client");
        }
    }
}
