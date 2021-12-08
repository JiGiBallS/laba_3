namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderHistory_OrdersId", "dbo.OrderHistories");
            DropIndex("dbo.Orders", new[] { "OrderHistory_OrdersId" });
            AddColumn("dbo.Products", "Order_OrdersId", c => c.Int());
            CreateIndex("dbo.Products", "Order_OrdersId");
            AddForeignKey("dbo.Products", "Order_OrdersId", "dbo.Orders", "OrdersId");
            DropColumn("dbo.Orders", "OrderHistory_OrdersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderHistory_OrdersId", c => c.Int());
            DropForeignKey("dbo.Products", "Order_OrdersId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_OrdersId" });
            DropColumn("dbo.Products", "Order_OrdersId");
            CreateIndex("dbo.Orders", "OrderHistory_OrdersId");
            AddForeignKey("dbo.Orders", "OrderHistory_OrdersId", "dbo.OrderHistories", "OrdersId");
        }
    }
}
