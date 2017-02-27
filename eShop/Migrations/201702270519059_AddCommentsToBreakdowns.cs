namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsToBreakdowns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breakdowns", "Comments", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breakdowns", "Comments");
        }
    }
}
