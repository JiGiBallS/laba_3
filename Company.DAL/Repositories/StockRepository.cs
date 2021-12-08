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
    public class StockRepository : IRepository<Stock>
    {
        private CompanyContext db;

        public StockRepository(CompanyContext context)
        {
            this.db = context;
        }

        public IEnumerable<Stock> GetAll()
        {
            var stock = db.Stocks.Include(q => q.Category).Include(z => z.Orders).ToList();
            return stock;
        }

        public Stock Get(int id)
        {
            return db.Stocks.Find(id);
        }

        public void Create(Stock order)
        {
            db.Stocks.Add(order);
        }

        public void Update(Stock order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Stock> Find(Func<Stock, Boolean> predicate)
        {
            return db.Stocks.Include(o => o.Orders).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Stock stock = db.Stocks.Find(id);
            if (stock != null)
                db.Stocks.Remove(stock);
        }

        public void UpdateInfo(List<int> tem)
        {
            throw new NotImplementedException();
        }

        //public void UpdateInfo(IEnumerable<Project> tem)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
