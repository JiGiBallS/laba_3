namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_OrdersId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_OrdersId" });
            RenameColumn(table: "dbo.Orders", name: "ProductsId", newName: "Stock_ProductsId");
            RenameIndex(table: "dbo.Orders", name: "IX_ProductsId", newName: "IX_Stock_ProductsId");
            AddColumn("dbo.Orders", "DateOfCompletion", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Orders", "Date_end_education");
            DropColumn("dbo.Products", "Order_OrdersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_OrdersId", c => c.Int());
            AddColumn("dbo.Orders", "Date_end_education", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Orders", "DateOfCompletion");
            RenameIndex(table: "dbo.Orders", name: "IX_Stock_ProductsId", newName: "IX_ProductsId");
            RenameColumn(table: "dbo.Orders", name: "Stock_ProductsId", newName: "ProductsId");
            CreateIndex("dbo.Products", "Order_OrdersId");
            AddForeignKey("dbo.Products", "Order_OrdersId", "dbo.Orders", "OrdersId");
        }
    }
}
