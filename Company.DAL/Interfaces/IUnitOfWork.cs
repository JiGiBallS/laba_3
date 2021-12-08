using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {     
        IRepository<Stock> Stock { get; }
        IRepository<Order> Order { get; }
        IRepository<ToOrder> ToOrder { get; }
        IRepository<OrderHistory> OrderHistory { get; }
        IRepository<Products> Products { get; }
        IRepository<Category> Category { get; }
        void Save();

        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}