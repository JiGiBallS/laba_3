using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using NLog;
using System.Collections.Generic;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;

namespace NLayerApp.WEB.Controllers
{
    public class OrderController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IEmployeeService employeeService;
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        //[HttpPost]
        //[Authorize(Roles = "admin")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(int[] selectedProjects, [Bind(Include = "EmployeesId,Name_employees,Surname_employees,Date_start_job,ProjectId,EducationId,GenderId,Date_end_education")] EmployeeViewModel employee, ProjectViewModel projects)
        //{
        //    try
        //    {
        //        var mapperEmployee = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
        //        var mapperProject = new MapperConfiguration(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>()).CreateMapper();
        //        List<int> selectedProject = new List<int>();
        //        if (selectedProjects != null)
        //         if (ModelState.IsValid)         
        //        {
        //            Logger.Trace("Попытка добавления нового сотрудника");
        //            var employeeDto = mapperEmployee.Map<EmployeeViewModel, EmployeeDTO>(employee);
                  
        //            employeeService.MakeEmployee(employeeDto, selectedProject);
        //            logger.Trace("Новый сотрудник добавлен");
        //            return RedirectToAction("Index");
        //        }
                //IEnumerable<EducationDTO> educationDtos = employeeService.GetEducations();
                //IEnumerable<GenderDTO> genderDto = employeeService.GetGenders();
                //ViewBag.EducationId = new SelectList(educationDtos, "EducationId", "Name_place_of_study");
                //ViewBag.Projects = new SelectList(employeeService.GetProjects().ToList(), "ProjectId");
                //ViewBag.GenderId = new SelectList(genderDto, "GenderId", "Name_Gender");
                //ViewBag.Projects = projectDto;
        //        return View(employee);
        //    }
        //    catch (BLL.Infrastructure.ValidationException ex)
        //    {
        //        logger.Error("Произошла непредвиденная ошибка");
        //        ModelState.AddModelError(ex.Property, ex.Message);
        //    }
        //    return View(employee);
        //}

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
