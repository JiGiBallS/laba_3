using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using MultilingualSite.Filters;
using NLog;

namespace NLayerApp.WEB.Controllers
{
    [Culture]
    public class CompanyController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        IEmployeeService employeeService;
        public CompanyController(IEmployeeService serv)
        {
            employeeService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<OrderDTO> orderDtos = employeeService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            logger.Trace("Вывод всех сторудиков в представление Index");
            var order = mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(orderDtos);
            return View(order);
        }

        public ActionResult Stock()
        {
            IEnumerable<StockDTO> stockDtos = employeeService.GetStocks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
            logger.Trace("Вывод всех товаров, которые есть на складе");
            var stock = mapper.Map<IEnumerable<StockDTO>, IEnumerable<StockViewModel>>(stockDtos);
            return View(stock);
        }

        public ActionResult OrderHistory()
        {
            IEnumerable<OrderHistoryDTO> stockDtos = employeeService.GetOrdersHistory();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderHistoryDTO, OrderHistoryViewModel>()).CreateMapper();
            logger.Trace("Вывод всех товаров, которые есть на складе");
            var stock = mapper.Map<IEnumerable<OrderHistoryDTO>, IEnumerable<OrderHistoryViewModel>>(stockDtos);
            return View(stock);
        }

        public ActionResult OrderProducts()
        {
            IEnumerable<ToOrderDTO> toorderkDtos = employeeService.GetToOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
            logger.Trace("Вывод всех товаров, которые есть на складе");
            var toorder = mapper.Map<IEnumerable<ToOrderDTO>, IEnumerable<ToOrderViewModel>>(toorderkDtos);
            return View(toorder);
        }


        //  [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
                IEnumerable<StockDTO> stockDtos = employeeService.GetStocks();
                var mapper1 = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, StockViewModel>()).CreateMapper();
                logger.Trace("Вывод всех товаров, которые есть на складе");
                var stock = mapper.Map<IEnumerable<StockDTO>, IEnumerable<StockViewModel>>(stockDtos);
                ViewBag.StockId = stock;
                var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
                IEnumerable<CategoryDTO> categoryDtos = employeeService.GetCategories();
                ViewBag.CategoryId = new SelectList(categoryDtos, "CategoryId", "NameCategory");
                return View();
            }
            catch (BLL.Infrastructure.ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult CreateOrderProducts()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ToOrderDTO, ToOrderViewModel>()).CreateMapper();
                var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
                IEnumerable<CategoryDTO> categoryDtos = employeeService.GetCategories();
                ViewBag.CategoryId = new SelectList(categoryDtos, "CategoryId", "NameCategory");
                return View();
            }
            catch (BLL.Infrastructure.ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderProducts([Bind(Include = "ProductsId,Title,Amount,Date_delivery,Category,Price,Manufacturer")] ToOrderViewModel toorder)
        {
            try
            {
                var mapperOrder = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
               
                if (ModelState.IsValid)
                {
                    logger.Trace("Попытка добавления нового заказа");
                    var toorderDto = mapperOrder.Map<ToOrderDTO>(toorder);
                    employeeService.MakeOrderProduct(toorderDto);
                    logger.Trace("Новый сотрудник добавлен");
                    return RedirectToAction("Index");
                }
                logger.Trace("При добавлении заказа одно либо несколько полей не корректны");
                return View(toorder);
            }
            catch (BLL.Infrastructure.ValidationException ex)
            {
                logger.Error("Произошла непредвиденная ошибка");
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(toorder);
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int[] selectedProducts, [Bind(Include = "OrdersId,Name_customer,Surname_customer,Email,MNumber,Date_Order,AllOrder,Amount,Status,DateOfCompletion")] OrderViewModel order)
        {
            try
            {
                var mapperOrder = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
                 var mapperStock = new MapperConfiguration(cfg => cfg.CreateMap<StockViewModel, StockDTO>()).CreateMapper();
                 var stockDtos = employeeService.GetStocks();
                 var stocksDto = mapperStock.Map<IEnumerable<StockDTO>, IEnumerable<StockViewModel>>(stockDtos);
                  List<int> selectedStocks = new List<int>();
                  if (selectedProducts != null)
                if (ModelState.IsValid)
                {
                    logger.Trace("Попытка добавления нового заказа");
                    var employeeDto = mapperOrder.Map<OrderViewModel, OrderDTO>(order);
                    foreach (var c in stocksDto.Where(co => selectedProducts.Contains(co.ProductsId)))
                      {
                     var cc = mapperOrder.Map<StockViewModel, StockDTO>(c);
                            employeeDto.Amount =+ c.Price;
                            selectedStocks.Add(c.ProductsId);
                     }
                    employeeDto.Date_Order = DateTime.Now;
                    employeeService.MakeOrder(employeeDto, selectedStocks); // selectedProject
                    logger.Trace("Новый сотрудник добавлен");
                    return RedirectToAction("Index");
                }
                logger.Trace("При добавлении заказа одно либо несколько полей не корректны");
                // IEnumerable<EducationDTO> educationDtos = employeeService.GetEducations();
                //IEnumerable<GenderDTO> genderDto = employeeService.GetGenders();
                //ViewBag.EducationId = new SelectList(educationDtos, "EducationId", "Name_place_of_study");
                //ViewBag.Projects = new SelectList(employeeService.GetProjects().ToList(), "ProjectId");
                //ViewBag.GenderId = new SelectList(genderDto, "GenderId", "Name_Gender");
                //  ViewBag.Projects = projectDto;
                return View(order);
            }
            catch (BLL.Infrastructure.ValidationException ex)
            {
                logger.Error("Произошла непредвиденная ошибка");
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

      //  [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            logger.Trace("Получен id сотрудника = " + id);
            OrderDTO employeeDto = employeeService.GetOrder(id);

            if (employeeDto == null)
            {
                logger.Error("Ошибка. Не найден заказ с id == " + id);
                ViewData["Message"] = "Данный заказ не найден";
                return View("Error");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            logger.Trace("Ошибка валидации");
            //IEnumerable<EducationDTO> educationDtos = employeeService.GetEducations();
            //IEnumerable<ProjectDTO> projectDtos = employeeService.GetProjects();
            //IEnumerable<GenderDTO> genderDto = employeeService.GetGenders();
           //// ViewBag.EducationId = new SelectList(educationDtos, "EducationId", "Name_place_of_study", employeeDto.EducationId);
           // ViewBag.ProjectId = new SelectList(projectDtos, "ProjectId", "Name_projects", employeeDto.ProjectId);
           // ViewBag.GenderId = new SelectList(genderDto, "GenderId", "Name_Gender", employeeDto.GenderId);
            logger.Trace("Попытка передать заказ в представление редактирования");
            ViewBag.StockId = mapper.Map<IEnumerable<StockDTO>, IEnumerable<StockViewModel>>(employeeService.GetStocks().ToList());
            var employee = mapper.Map<OrderDTO, OrderViewModel>(employeeDto);
            List<int> ProjectCheck = new List<int>();
            foreach (var item in employeeDto.Stocks)
            {
                ProjectCheck.Add(item.ProductsId);
            }
            ViewBag.ProjectCheck = ProjectCheck;
            return View(employee);
        }



        [HttpPost]
      //  [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int[] selectedProducts, [Bind(Include = "OrdersId,Name_customer,Surname_customer,Email,MNumber,Date_Order,AllOrder,Amount,Status,DateOfCompletion")] OrderViewModel order)
        {
            try
            {
                var mapperP = new MapperConfiguration(cfg => cfg.CreateMap<StockViewModel, StockDTO>()).CreateMapper();
                var stocks = employeeService.GetStocks().ToList();
                if (selectedProducts != null)
                //  if (ModelState.IsValid)
                {
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
                    logger.Trace("Попытка изменения сотрудника сотрудника");
                    var orders = mapper.Map<OrderViewModel, OrderDTO>(order);
                    List<int> selectedProject = new List<int>();
                    foreach (var c in stocks.Where(co => selectedProducts.Contains(co.ProductsId)))
                    {
                        selectedProject.Add(c.ProductsId);
                    }
                    employeeService.UpdateOrder(orders, selectedProject);
                    logger.Trace("Заказ изменён");
                    return RedirectToAction("Index");
                }
                //ViewBag.Projects = mapperP.Map<IEnumerable<ProjectDTO>, IEnumerable<ProjectViewModel>>(employeeService.GetProjects().ToList());
                //IEnumerable<EducationDTO> educationDtos = employeeService.GetEducations();
                //IEnumerable<ProjectDTO> projectDtos = employeeService.GetProjects();
                //IEnumerable<GenderDTO> genderDto = employeeService.GetGenders();
                var Orders = employeeService.GetOrder(order.OrdersId);
                //ViewBag.EducationId = new SelectList(educationDtos, "EducationId", "Name_place_of_study");
                //ViewBag.ProjectId = new SelectList(projectDtos, "ProjectId", "Name_projects");
                //ViewBag.GenderId = new SelectList(genderDto, "GenderId", "Name_Gender");
                List<int> ProjectCheck = new List<int>();
                foreach (var item in Orders.Stocks)
                {
                    ProjectCheck.Add(item.ProductsId);
                }
                ViewBag.ProjectCheck = ProjectCheck;
                return View(order);
            }

            catch (BLL.Infrastructure.ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                ViewData["Message"] = "Произошла непредвиденная ошибка";
                return View("Error");
            }

        }
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            logger.Trace("Попытка удаления сотрудника " + id);
            OrderDTO order = employeeService.GetOrder(id);
            if (id != null & order != null)
            {
                employeeService.DeleteOrder(id);
                logger.Trace("Сотрудник №" + id + " удалён");
            }
            else
            {
                ViewData["Message"] = "Данный сотрудник не найден";
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            OrderDTO orderDto = employeeService.GetOrder(id);
            var order = mapper.Map<OrderDTO, OrderViewModel>(orderDto);
            //var gender = employeeService.GetGender(employeeDto.GenderId);
            //var education = employeeService.GetEducation(employeeDto.EducationId);
            if (id == null)
            {
                logger.Error("Ошибка. Не найден студент с id == " + id);
                ViewData["Message"] = "Данный сотрудник не найден";
            }
            ViewBag.OrdersId = order.OrdersId;
            ViewBag.Name_customer = order.Name_customer;
            ViewBag.Surname_customer = order.Surname_customer;
            ViewBag.Amount = order.Amount;
            ViewBag.DateOfCompletion = order.DateOfCompletion;
            ViewBag.Email = order.Email;
            ViewBag.MNumber = order.MNumber;
            ViewBag.Date_Order = order.Date_Order;
            return View(order);
        }

        public ActionResult Complete(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            OrderDTO orderDto = employeeService.GetOrder(id);
            var orderhistiryDto = new OrderHistoryViewModel();
            orderhistiryDto.OrdersId = orderDto.OrdersId;
            orderhistiryDto.Name_customer = orderDto.Name_customer;
            orderhistiryDto.Surname_customer = orderDto.Surname_customer;
            orderhistiryDto.Date_Order = orderDto.Date_Order;
            orderhistiryDto.Amount = orderDto.Amount;
            orderhistiryDto.DateOfCompletion = orderDto.DateOfCompletion;
            orderhistiryDto.MNumber = orderDto.MNumber;
            orderhistiryDto.Email = orderDto.Email;
            // var orderhistiry = mapper.Map<OrderDTO, OrderHistoryDTO>(orderhistiryDto);
            var mapper1 = new MapperConfiguration(cfg => cfg.CreateMap<OrderHistoryDTO, OrderHistoryViewModel>()).CreateMapper();

            orderhistiryDto.Status = 1;
            var orderhistiry = mapper.Map<OrderHistoryViewModel, OrderHistoryDTO>(orderhistiryDto);
            employeeService.AddOrderToHistory(orderhistiry);

            logger.Trace("Попытка удаления сотрудника " + id);
            OrderDTO order = employeeService.GetOrder(id);
            if (id != null & order != null)
            {
                employeeService.DeleteOrder(id);
                logger.Trace("Сотрудник №" + id + " удалён");
            }
            else
            {
                ViewData["Message"] = "Данный заказ не найден";
                return View("Error");
            }
            return RedirectToAction("Index");

        }

        public ActionResult Cancel(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            OrderDTO orderDto = employeeService.GetOrder(id);
            var orderhistiryDto = new OrderHistoryViewModel();

            orderhistiryDto.OrdersId = orderDto.OrdersId;
            orderhistiryDto.Name_customer = orderDto.Name_customer;
            orderhistiryDto.Surname_customer = orderDto.Surname_customer;
            orderhistiryDto.Date_Order = orderDto.Date_Order;
            orderhistiryDto.Amount = orderDto.Amount;
            orderhistiryDto.DateOfCompletion = orderDto.DateOfCompletion;
            orderhistiryDto.MNumber = orderDto.MNumber;
            orderhistiryDto.Email = orderDto.Email;
            // var orderhistiry = mapper.Map<OrderDTO, OrderHistoryDTO>(orderhistiryDto);
            var mapper1 = new MapperConfiguration(cfg => cfg.CreateMap<OrderHistoryDTO, OrderHistoryViewModel>()).CreateMapper();

            orderhistiryDto.Status = 0;
            var orderhistiry = mapper.Map<OrderHistoryViewModel, OrderHistoryDTO>(orderhistiryDto);
            employeeService.AddOrderToHistory(orderhistiry);

            logger.Trace("Попытка удаления сотрудника " + id);
            OrderDTO order = employeeService.GetOrder(id);
            if (id != null & order != null)
            {
                employeeService.DeleteOrder(id);
                logger.Trace("Сотрудник №" + id + " удалён");
            }
            else
            {
                ViewData["Message"] = "Данный заказ не найден";
                return View("Error");
            }
            return RedirectToAction("Index");

        }



        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {
                cookie = new HttpCookie("lang")
                {
                    HttpOnly = false,
                    Value = lang,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        protected override void Dispose(bool disposing)
        {
            employeeService.Dispose();
            base.Dispose(disposing);
        }
    }
}