namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stocks", "CategoryId");
            AddForeignKey("dbo.Stocks", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Stocks", new[] { "CategoryId" });
            DropColumn("dbo.Stocks", "CategoryId");
        }
    }
}
