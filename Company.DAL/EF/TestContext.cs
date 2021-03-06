using System;
using System.Collections.Generic;
using System.Data.Entity;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("ShopConnection")
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ToOrder> ToOrders { get; set; }
        public DbSet<Category> Categoryies { get; set; }
        static CompanyContext()
        {
            Database.SetInitializer<CompanyContext>(new StoreDbInitializer());
        }
        public CompanyContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(c => c.Stocks)
                .WithMany(s => s.Orders)
                .Map(t => t.MapLeftKey("OrdersId")
                .MapRightKey("ProductsId")
                .ToTable("OrderProduct"));
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<Category>()
               .HasMany(p => p.Stocks)
               .WithRequired(p => p.Category);
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CompanyContext>
        {
            //protected override void Seed(CompanyContext db)
            //{
            //    Gender gender1 = new Gender { GenderId = 1, Name_Gender = "Male" };
            //    Gender gender2 = new Gender { GenderId = 2, Name_Gender = "Female" };
            //    Gender gender3 = new Gender { GenderId = 3, Name_Gender = "Unknown" };
            //    db.Genders.AddRange(new List<Gender> { gender1, gender2, gender3 });
            //    db.SaveChanges();

            //    Project project1 = new Project { Name_projects = "Dr.Web", Date_end_projects = DateTime.Today, Date_start_projects = DateTime.Today };
            //    Project project2 = new Project { Name_projects = "Grizli", Date_end_projects = DateTime.Today, Date_start_projects = DateTime.Today };
            //    Project project3 = new Project { Name_projects = "CS:GO", Date_end_projects = DateTime.Today, Date_start_projects = DateTime.Today };
            //    db.Projects.AddRange(new List<Project> { project1, project2, project3 });
            //    db.SaveChanges();

            //    Education education1 = new Education { EducationId = 1, Name_place_of_study = "NGAEK" };
            //    Education education2 = new Education { EducationId = 2, Name_place_of_study = "BGY" };
            //    Education education3 = new Education { EducationId = 3, Name_place_of_study = "BGYiR" };
            //    db.Educations.AddRange(new List<Education> { education1, education2, education3 });
            //    db.SaveChanges();

            //    Employee employee1 = new Employee { EmployeesId = 1, Name_employees = "Fedya", Surname_employees = "Tsybuk", Date_start_job = DateTime.Today, EducationId = education1.EducationId, GenderId = gender1.GenderId, Date_end_education = DateTime.Today };
            //    Employee employee2 = new Employee { EmployeesId = 2, Name_employees = "Sasha", Surname_employees = "Novik", Date_start_job = DateTime.Today, EducationId = education2.EducationId, GenderId = gender2.GenderId, Date_end_education = DateTime.Today };
            //    Employee employee3 = new Employee { EmployeesId = 3, Name_employees = "Dima", Surname_employees = "Lyaluk", Date_start_job = DateTime.Today, EducationId = education3.EducationId, GenderId = gender3.GenderId, Date_end_education = DateTime.Today };
            //    db.Employees.AddRange(new List<Employee> { employee1, employee2, employee3 });
            //    db.SaveChanges();


            //    project1.Employees.Add(employee1);
            //    project1.Employees.Add(employee2);
            //    project2.Employees.Add(employee2);
            //    project2.Employees.Add(employee3);
            //    project3.Employees.Add(employee1);
            //    project3.Employees.Add(employee3);
            //    db.SaveChanges();
            //}
        }
    }
}