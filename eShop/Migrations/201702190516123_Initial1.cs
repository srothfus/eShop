namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breakdowns",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Equipment = c.String(nullable: false, maxLength: 20),
                        TimeOfBreakdown = c.DateTime(nullable: false),
                        LocationOfBreakdown = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        WorkDoneBy = c.String(),
                        PaymentTypeId = c.Byte(),
                        Payment = c.String(),
                        IsFixed = c.Boolean(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        IsResolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        ContactName = c.String(maxLength: 50),
                        Location = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Equipment = c.String(maxLength: 10),
                        DriverName = c.String(maxLength: 50),
                        HasInvoice = c.Boolean(nullable: false),
                        AccountNumber = c.String(maxLength: 100),
                        DateIssued = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        Cost = c.String(maxLength: 10),
                        InvoiceNumber = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Breakdowns");
        }
    }
}
