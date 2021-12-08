namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Stock_ProductsId", "dbo.Stocks");
            DropIndex("dbo.Products", new[] { "Stock_ProductsId" });
            AddColumn("dbo.Stocks", "Category", c => c.String());
            AddColumn("dbo.Stocks", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "Manufacturer", c => c.String());
            AddColumn("dbo.Stocks", "Date_of_delivery", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Products", "Stock_ProductsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Stock_ProductsId", c => c.Int());
            DropColumn("dbo.Stocks", "Date_of_delivery");
            DropColumn("dbo.Stocks", "Manufacturer");
            DropColumn("dbo.Stocks", "Price");
            DropColumn("dbo.Stocks", "Category");
            CreateIndex("dbo.Products", "Stock_ProductsId");
            AddForeignKey("dbo.Products", "Stock_ProductsId", "dbo.Stocks", "ProductsId");
        }
    }
}
