using System;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CompanyContext db;
        private StockRepository stockRepository;
        private OrderRepository orderRepository;
        private ToOrderRepository toorderRepository;
        private ProductsRepositoty productsRepository;
        private OrderHistoryRepository orderhistoryRepository;
        private CategoryRepository categoryRepository;

        private ApplicationContext dab;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public EFUnitOfWork(string connectionString)
        {
            db = new CompanyContext(connectionString);
        }
        public IRepository<Stock> Stock
        {
            get
            {
                if (stockRepository == null)
                    stockRepository = new StockRepository(db);
                return stockRepository;
            }
        }

        public IRepository<Order> Order
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<ToOrder> ToOrder
        {
            get
            {
                if (toorderRepository == null)
                    toorderRepository = new ToOrderRepository(db);
                return toorderRepository;
            }
        }
        public IRepository<Products> Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new ProductsRepositoty(db);
                return productsRepository;
            }
        }
        public IRepository<OrderHistory> OrderHistory
        {
            get
            {
                if (orderhistoryRepository == null)
                    orderhistoryRepository = new OrderHistoryRepository(db);
                return orderhistoryRepository;
            }
        }
        public IRepository<Category> Category
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void IdentityUnitOfWork(string connectionString)
        {
            dab = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dab));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(dab));
            clientManager = new ClientManager(dab);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await dab.SaveChangesAsync();
        }

          
    }
}