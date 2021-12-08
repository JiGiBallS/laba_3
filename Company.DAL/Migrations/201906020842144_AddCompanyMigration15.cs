namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.ToOrders", "CategoryId", c => c.Int());
            CreateIndex("dbo.ToOrders", "CategoryId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.ToOrders", "CategoryId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Products", "Category");
            DropColumn("dbo.Stocks", "Category");
            DropColumn("dbo.ToOrders", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToOrders", "Category", c => c.String());
            AddColumn("dbo.Stocks", "Category", c => c.String());
            AddColumn("dbo.Products", "Category", c => c.String());
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ToOrders", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ToOrders", new[] { "CategoryId" });
            DropColumn("dbo.ToOrders", "CategoryId");
            DropColumn("dbo.Products", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
