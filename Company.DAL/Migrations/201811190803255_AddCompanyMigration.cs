namespace Company.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        Name_place_of_study = c.String(),
                    })
                .PrimaryKey(t => t.EducationId);
            
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
                .PrimaryKey(t => t.EmployeesId)
                .ForeignKey("dbo.Educations", t => t.EducationId)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.EducationId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Name_Gender = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
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
                "dbo.ProjectEmployees",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        EmployeesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.EmployeesId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeesId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.EmployeesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectEmployees", "EmployeesId", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployees", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Employees", "EducationId", "dbo.Educations");
            DropIndex("dbo.ProjectEmployees", new[] { "EmployeesId" });
            DropIndex("dbo.ProjectEmployees", new[] { "ProjectId" });
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropIndex("dbo.Employees", new[] { "EducationId" });
            DropTable("dbo.ProjectEmployees");
            DropTable("dbo.Projects");
            DropTable("dbo.Genders");
            DropTable("dbo.Employees");
            DropTable("dbo.Educations");
        }
    }
}
