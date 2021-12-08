namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "Amount");
        }
    }
}
