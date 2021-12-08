namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistories", "Name_customer", c => c.String());
            AddColumn("dbo.OrderHistories", "Surname_customer", c => c.String());
            AddColumn("dbo.OrderHistories", "Date_Order", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.OrderHistories", "AllOrder", c => c.Int(nullable: false));
            AddColumn("dbo.OrderHistories", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.OrderHistories", "DateOfCompletion", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.OrderHistories", "MNumber", c => c.String());
            AddColumn("dbo.OrderHistories", "Email", c => c.String());
            DropColumn("dbo.OrderHistories", "Date_delivery");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderHistories", "Date_delivery", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.OrderHistories", "Email");
            DropColumn("dbo.OrderHistories", "MNumber");
            DropColumn("dbo.OrderHistories", "DateOfCompletion");
            DropColumn("dbo.OrderHistories", "Amount");
            DropColumn("dbo.OrderHistories", "AllOrder");
            DropColumn("dbo.OrderHistories", "Date_Order");
            DropColumn("dbo.OrderHistories", "Surname_customer");
            DropColumn("dbo.OrderHistories", "Name_customer");
        }
    }
}
