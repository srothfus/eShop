namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBreakdownsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breakdowns", "Operator", c => c.String());
            AddColumn("dbo.Breakdowns", "ProblemDescription", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Breakdowns", "ActionDescription", c => c.String(maxLength: 255));
            AddColumn("dbo.PurchaseOrders", "PONumber", c => c.String());
            CreateIndex("dbo.Breakdowns", "PaymentTypeId");
            CreateIndex("dbo.PurchaseOrders", "CustomerId");
            AddForeignKey("dbo.Breakdowns", "PaymentTypeId", "dbo.PaymentTypes", "Id");
            AddForeignKey("dbo.PurchaseOrders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Breakdowns", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Breakdowns", "Description", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.PurchaseOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Breakdowns", "PaymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.PurchaseOrders", new[] { "CustomerId" });
            DropIndex("dbo.Breakdowns", new[] { "PaymentTypeId" });
            DropColumn("dbo.PurchaseOrders", "PONumber");
            DropColumn("dbo.Breakdowns", "ActionDescription");
            DropColumn("dbo.Breakdowns", "ProblemDescription");
            DropColumn("dbo.Breakdowns", "Operator");
        }
    }
}
