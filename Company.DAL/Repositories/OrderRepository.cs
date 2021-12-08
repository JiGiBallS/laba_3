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
    public class OrderRepository : IRepository<Order>
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private CompanyContext db;

        public OrderRepository(CompanyContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {            

            var orders = db.Orders.Include(z => z.Stocks).ToList();
            return orders;
        }

        public Order Get(int id)
        {
            var order = db.Orders.Find(id);
            return order;
        }

        public void Create(Order orderDto)
        {
            db.Orders.Add(orderDto);
        }

        public void Update(Order orderDto)
        {
            var order = db.Orders
       // Загрузить покупателя с фамилией "Иванов"
       .Where(c => c.OrdersId == orderDto.OrdersId)
       .FirstOrDefault();
            order.Name_customer = order.Name_customer;
            order.Surname_customer = order.Surname_customer;
            order.MNumber = order.MNumber;
            order.Email = order.Email;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders
                .Where(predicate)
                .ToList();
        }

        public void Delete(int id)
        {
            Order order= db.Orders.Find(id);

            if (order != null)
                db.Orders.Remove(order);
        }       
    }
}