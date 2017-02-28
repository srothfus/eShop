namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBreakdownModelId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Breakdowns");
            AlterColumn("dbo.Breakdowns", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Breakdowns", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Breakdowns");
            AlterColumn("dbo.Breakdowns", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Breakdowns", "Id");
        }
    }
}
