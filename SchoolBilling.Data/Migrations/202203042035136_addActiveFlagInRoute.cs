namespace SchoolBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActiveFlagInRoute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Route", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Route", "IsActive");
        }
    }
}
