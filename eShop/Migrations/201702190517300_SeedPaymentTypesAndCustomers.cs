namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPaymentTypesAndCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Id, Name) VALUES (1, 'TA/Petro')");
            Sql("INSERT INTO Customers (Id, Name) VALUES (2, 'Speedco')");
            Sql("INSERT INTO Customers (Id, Name) VALUES (3, 'Blue Beacon')");

            Sql("INSERT INTO PaymentTypes (Id, Name) VALUES (1, 'Purchase Order')");
            Sql("INSERT INTO PaymentTypes (Id, Name) VALUES (2, 'Comcheck')");
            Sql("INSERT INTO PaymentTypes (Id, Name) VALUES (3, 'Driver Paid')");
            Sql("INSERT INTO PaymentTypes (Id, Name) VALUES (4, 'Driver Fixed')");
            Sql("INSERT INTO PaymentTypes (Id, Name) VALUES (5, 'No Charge')");
        }
        
        public override void Down()
        {
        }
    }
}
