using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NLayerApp.DAL.Repositories
{
    public class OrderHistoryRepository : IRepository<OrderHistory>
    {
        private CompanyContext db;

        public OrderHistoryRepository(CompanyContext context)
        {
            this.db = context;
        }

        public IEnumerable<OrderHistory> GetAll()
        {
            return db.OrderHistories;
        }

        public OrderHistory Get(int id)
        {
            return db.OrderHistories.Find(id);
        }

        public void Create(OrderHistory OrderHistory)
        {
            db.OrderHistories.Add(OrderHistory);
        }

        public void Update(OrderHistory OrderHistory)
        {
            db.Entry(OrderHistory).State = EntityState.Modified;
        }
        public IEnumerable<OrderHistory> Find(Func<OrderHistory, Boolean> predicate)
        {
            return db.OrderHistories.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            OrderHistory OrderHistory = db.OrderHistories.Find(id);
            if (OrderHistory != null)
                db.OrderHistories.Remove(OrderHistory);
        }

        public void Update(OrderHistory item, IEnumerable<OrderHistory> tem)
        {
            throw new NotImplementedException();
        }

        public void UpdateInfo(List<int> tem)
        {
            throw new NotImplementedException();
        }

        public void UpdateInfo(IEnumerable<OrderHistory> tem)
        {
            throw new NotImplementedException();
        }
    }
}
