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
    public class CategoryRepository : IRepository<Category>
    {
        private CompanyContext db;

        public CategoryRepository(CompanyContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categoryies.ToList();
        }

        public Category Get(int id)
        {
            return db.Categoryies.Find(id);
        }

        public void Create(Category category)
        {
            db.Categoryies.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }
        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return db.Categoryies.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Category category = db.Categoryies.Find(id);
            if (category != null)
                db.Categoryies.Remove(category);
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
