namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToOrders",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Amount = c.Int(nullable: false),
                        Date_delivery = c.DateTime(nullable: false, storeType: "date"),
                        Category = c.String(),
                        Price = c.Int(nullable: false),
                        Manufacturer = c.String(),
                    })
                .PrimaryKey(t => t.ProductsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToOrders");
        }
    }
}
