using System;
using System.Collections.Generic;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;
using NLog;

namespace NLayerApp.DAL.Repositories
{
    public class ToOrderRepository : IRepository<ToOrder>
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private CompanyContext db;

        public ToOrderRepository(CompanyContext context)
        {
            this.db = context;
        }

        public IEnumerable<ToOrder> GetAll()
        {
            var toorder = db.ToOrders.Include(q => q.Category).ToList();
            return toorder;
        }

        public ToOrder Get(int id)
        {
            var toorder = db.ToOrders.Find(id);
            return toorder;
        }

        public void Create(ToOrder toorderDto)
        {
            db.ToOrders.Add(toorderDto);
        }

        public void Update(ToOrder employeeDto)
        {
       //     var employee = db.Orders
       //// Загрузить покупателя с фамилией "Иванов"
       //.Where(c => c.EmployeesId == employeeDto.EmployeesId)
       //.FirstOrDefault();
       //     employee.Name_employees = employeeDto.Name_employees;
       //     employee.Surname_employees = employeeDto.Surname_employees;
       //     employee.GenderId = employeeDto.GenderId;
       //     employee.EducationId = employeeDto.EducationId;
       //     employee.GenderId = employeeDto.GenderId;
       //     employee.Projects = employeeDto.Projects;
       //     employee.Date_start_job = employeeDto.Date_start_job;
       //     employee.Date_end_education = employeeDto.Date_end_education;            
        }

        public IEnumerable<ToOrder> Find(Func<ToOrder, Boolean> predicate)
        {
            return db.ToOrders
                .Where(predicate)
                .ToList();
        }

        public void Delete(int id)
        {
            ToOrder toorder= db.ToOrders.Find(id);

            if (toorder != null)
                db.ToOrders.Remove(toorder);
        }       
    }
}