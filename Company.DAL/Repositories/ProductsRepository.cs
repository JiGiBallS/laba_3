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
    public class ProductsRepositoty : IRepository<Products>
    {
        private CompanyContext db;

        public ProductsRepositoty(CompanyContext context)
        {
            this.db = context;
        }

        public IEnumerable<Products> GetAll()
        {
          
            return db.Products;
        }

        public Products Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Products Products)
        {
            db.Products.Add(Products);
        }

        public void Update(Products Products)
        {
            db.Entry(Products).State = EntityState.Modified;
        }
        public IEnumerable<Products> Find(Func<Products, Boolean> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Products Products = db.Products.Find(id);
            if (Products != null)
                db.Products.Remove(Products);
        }

        public void Update(Products item, IEnumerable<Products> tem)
        {
            throw new NotImplementedException();
        }

        public void UpdateInfo(List<int> tem)
        {
            throw new NotImplementedException();
        }
    }
}