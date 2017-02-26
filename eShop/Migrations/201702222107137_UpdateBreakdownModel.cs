namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBreakdownModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breakdowns", "Location", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Breakdowns", "LocationOfBreakdown");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Breakdowns", "LocationOfBreakdown", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Breakdowns", "Location");
        }
    }
}
