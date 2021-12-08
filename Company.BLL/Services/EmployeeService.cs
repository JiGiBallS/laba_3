using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using NLog;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NLayerApp.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork Database { get; set; }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder(OrderDTO orderDto, List<int> selectedStocks)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDto);
            foreach (var item in selectedStocks)
            {
                order.Stocks.Add(Database.Stock.Get(item));
            }
            Database.Order.Create(order);
            Database.Save();
        }
        public void MakeOrderProduct(ToOrderDTO toorderDto) //, List<int> selectedProject)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ToOrderDTO, ToOrder>()).CreateMapper();
            var toorder = mapper.Map<ToOrderDTO, ToOrder>(toorderDto);
            Database.ToOrder.Create(toorder);
            Database.Save();
        }

        public void AddOrderToHistory(OrderHistoryDTO orderhistoryDto) //, List<int> selectedProject)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderHistoryDTO, OrderHistory>()).CreateMapper();
            var orderhistory = mapper.Map<OrderHistoryDTO, OrderHistory>(orderhistoryDto);
            Database.OrderHistory.Create(orderhistory);
            Database.Save();
        }

        public void UpdateOrder(OrderDTO orderDto, List<int> selectedProducts)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDto);
            foreach (var item in selectedProducts)
            {
                order.Stocks.Add(Database.Stock.Get(item));
            }
            Database.Order.Update(order);
            Database.Save();
        }

        public void DeleteOrder(int? id)
        {
            Database.Order.Delete(id.Value);
            Database.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Category.GetAll());
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id заказа");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            var orderDto = mapper.Map<Order, OrderDTO>(Database.Order.Get(id.Value));
            if (orderDto == null)
                throw new ValidationException("Пол не найден");
            return orderDto;
        }

        public CategoryDTO GetCategory(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Категории");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            var categoryDTO = mapper.Map<Category, CategoryDTO>(Database.Category.Get(id.Value));
            if (categoryDTO == null)
                throw new ValidationException("Пол не найден");
            return categoryDTO;
        }

        //public IEnumerable<EducationDTO> GetEducations()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Gender, GenderDTO>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Education>, List<EducationDTO>>(Database.Educations.GetAll());
        //}

        //public EducationDTO GetEducation(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException("Не установлено id учереждения образования");
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Education, EducationDTO>()).CreateMapper();
        //    var educationDto = mapper.Map<Education, EducationDTO>(Database.Educations.Get(id.Value));            
        //    if (educationDto == null)
        //        throw new ValidationException("Учереждение образования не найдено");
        //    return educationDto;
        //}

        //public IEnumerable<ProjectDTO> GetProjects()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(Database.Projects.GetAll());
        //}

        //public ProjectDTO GetProject(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException("Не установлено id проекта");
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();
        //    var projectDto = mapper.Map<Project, ProjectDTO>(Database.Projects.Get(id.Value));
        //    if (projectDto == null)
        //        throw new ValidationException("Проект не найден");
        //    return projectDto;
        //}

        public void MakeProject(OrderDTO orderDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDto);
            Database.Order.Create(order);
            Database.Save();
           }

        //public void UpdateProject(ProjectDTO projectDto)
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, Project>()).CreateMapper();
        //    var project = mapper.Map<ProjectDTO, Project>(projectDto);
        //    Database.Projects.Update(project);
        //    Database.Save();
        //}

        //public void UpdateProjectInfo(IEnumerable<EmployeeDTO> selectedEmployeeDto)
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, Employee>()).CreateMapper();
        //    var selectedProject = mapper.Map<IEnumerable<EmployeeDTO>, IEnumerable<Project>>(selectedEmployeeDto);
        //    Database.Employees.UpdateInfo(selectedProject);
        //}

        //public void UpdateEmployeeInfo(List<int> selectedProject)
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, Project>()).CreateMapper();
        //    var selectedProject = mapper.Map<IEnumerable<ProjectDTO>, IEnumerable<Project>>(selectedProjectDto);
        //    Database.Employees.UpdateInfo(selectedProject);
        //    Database.Save();
        //}

        //public void DeleteProject(int? id)
        //{
        //    Database.Projects.Delete(id.Value);
        //    Database.Save();
        //}

        public IEnumerable<OrderDTO> GetOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            var allOrder = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Order.GetAll());
            return allOrder;
        }

        public IEnumerable<OrderHistoryDTO> GetOrdersHistory()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderHistory, OrderHistoryDTO>()).CreateMapper();
            var allOrderHistory = mapper.Map<IEnumerable<OrderHistory>, List<OrderHistoryDTO>>(Database.OrderHistory.GetAll());
            return allOrderHistory;
        }
        

        public IEnumerable<StockDTO> GetStocks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stock, StockDTO>()).CreateMapper();
            var allStock = mapper.Map<IEnumerable<Stock>, List<StockDTO>>(Database.Stock.GetAll());
            return allStock;
        }
        public IEnumerable<ToOrderDTO> GetToOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap <ToOrder, ToOrderDTO > ()).CreateMapper();
            var allOrderProdycts = mapper.Map<IEnumerable<ToOrder>, List<ToOrderDTO>>(Database.ToOrder.GetAll());
            return allOrderProdycts;
        }

        //public EmployeeDTO GetEmployee(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException("Не установлено id сотрудника");
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
        //    var employeeDto = mapper.Map<Employee, EmployeeDTO>(Database.Employees.Get(id.Value));
        //    if (employeeDto == null)
        //        throw new ValidationException("Сотрудник не найден");
        //    return employeeDto;
        //}

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}