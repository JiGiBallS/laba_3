using System;
using System.Collections.Generic;
using NLayerApp.BLL.DTO;



namespace NLayerApp.BLL.Interfaces
{
    public interface IEmployeeService
    {

        void MakeOrder(OrderDTO orderDto, List<int> selectedStocks);
        void UpdateOrder(OrderDTO orderDto, List<int> selectedProducts);
        //EmployeeDTO GetEmployee(int? id);
        void DeleteOrder(int? id);
        IEnumerable<OrderDTO> GetOrders();
        IEnumerable<StockDTO> GetStocks();
        IEnumerable<ToOrderDTO> GetToOrders();
        IEnumerable<OrderHistoryDTO> GetOrdersHistory();
        OrderDTO GetOrder(int? id);
        CategoryDTO GetCategory(int? id);
        IEnumerable<CategoryDTO> GetCategories();
        void MakeOrderProduct(ToOrderDTO toorderDto);
        void AddOrderToHistory(OrderHistoryDTO orderhistoryDto);

        //EducationDTO GetEducation(int? id);
        //IEnumerable<EducationDTO> GetEducations();

        //ProjectDTO GetProject(int? id);
        //IEnumerable<ProjectDTO> GetProjects();
        //void MakeProject(ProjectDTO projectDTO);
        //void UpdateProject(ProjectDTO projectDto);
        //void DeleteProject(int? id);

        void Dispose();
 
    }
}