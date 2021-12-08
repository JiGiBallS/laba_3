namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Stock_ProductsId", "dbo.Stocks");
            DropIndex("dbo.Orders", new[] { "Stock_ProductsId" });
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrdersId = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrdersId, t.ProductsId })
                .ForeignKey("dbo.Orders", t => t.OrdersId, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.ProductsId, cascadeDelete: true)
                .Index(t => t.OrdersId)
                .Index(t => t.ProductsId);
            
           // DropColumn("dbo.Orders", "Stock_ProductsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Stock_ProductsId", c => c.Int());
            DropForeignKey("dbo.OrderProduct", "ProductsId", "dbo.Stocks");
            DropForeignKey("dbo.OrderProduct", "OrdersId", "dbo.Orders");
            DropIndex("dbo.OrderProduct", new[] { "ProductsId" });
            DropIndex("dbo.OrderProduct", new[] { "OrdersId" });
            DropTable("dbo.OrderProduct");
            CreateIndex("dbo.Orders", "Stock_ProductsId");
            AddForeignKey("dbo.Orders", "Stock_ProductsId", "dbo.Stocks", "ProductsId");
        }
    }
}
