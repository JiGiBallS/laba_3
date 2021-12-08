namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.ProjectEmployees", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectEmployees", "EmployeesId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "EducationId" });
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropIndex("dbo.ProjectEmployees", new[] { "ProjectId" });
            DropIndex("dbo.ProjectEmployees", new[] { "EmployeesId" });
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        OrdersId = c.Int(nullable: false, identity: true),
                        Date_delivery = c.DateTime(nullable: false, storeType: "date"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdersId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersId = c.Int(nullable: false, identity: true),
                        Name_customer = c.String(),
                        Surname_customer = c.String(),
                        Date_Order = c.DateTime(nullable: false, storeType: "date"),
                        ProductsId = c.Int(),
                        Date_end_education = c.DateTime(nullable: false, storeType: "date"),
                        OrderHistory_OrdersId = c.Int(),
                    })
                .PrimaryKey(t => t.OrdersId)
                .ForeignKey("dbo.Stocks", t => t.ProductsId)
                .ForeignKey("dbo.OrderHistories", t => t.OrderHistory_OrdersId)
                .Index(t => t.ProductsId)
                .Index(t => t.OrderHistory_OrdersId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category = c.String(),
                        Price = c.Int(nullable: false),
                        Stock_ProductsId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductsId)
                .ForeignKey("dbo.Stocks", t => t.Stock_ProductsId)
                .Index(t => t.Stock_ProductsId);
            
            DropTable("dbo.Educations");
            DropTable("dbo.Employees");
            DropTable("dbo.Genders");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        EmployeesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.EmployeesId });
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name_projects = c.String(),
                        Date_start_projects = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Date_end_projects = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Name_Gender = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeesId = c.Int(nullable: false, identity: true),
                        Name_employees = c.String(),
                        Surname_employees = c.String(),
                        Date_start_job = c.DateTime(nullable: false, storeType: "date"),
                        ProjectId = c.Int(nullable: false),
                        EducationId = c.Int(),
                        GenderId = c.Int(nullable: false),
                        Date_end_education = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.EmployeesId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        Name_place_of_study = c.String(),
                    })
                .PrimaryKey(t => t.EducationId);
            
            DropForeignKey("dbo.Products", "Stock_ProductsId", "dbo.Stocks");
            DropForeignKey("dbo.Orders", "OrderHistory_OrdersId", "dbo.OrderHistories");
            DropForeignKey("dbo.Orders", "ProductsId", "dbo.Stocks");
            DropIndex("dbo.Products", new[] { "Stock_ProductsId" });
            DropIndex("dbo.Orders", new[] { "OrderHistory_OrdersId" });
            DropIndex("dbo.Orders", new[] { "ProductsId" });
            DropTable("dbo.Products");
            DropTable("dbo.Stocks");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderHistories");
            CreateIndex("dbo.ProjectEmployees", "EmployeesId");
            CreateIndex("dbo.ProjectEmployees", "ProjectId");
            CreateIndex("dbo.Employees", "GenderId");
            CreateIndex("dbo.Employees", "EducationId");
            AddForeignKey("dbo.ProjectEmployees", "EmployeesId", "dbo.Employees", "EmployeesId", cascadeDelete: true);
            AddForeignKey("dbo.ProjectEmployees", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "GenderId", "dbo.Genders", "GenderId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "EducationId", "dbo.Educations", "EducationId");
        }
    }
}
