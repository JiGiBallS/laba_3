namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "MNumber", c => c.String());
            AddColumn("dbo.Orders", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "MNumber");
        }
    }
}
