using APIApplication.Core;
using APIApplication.MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace APIApplication.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDBContext db;
        public DbSet<T> table;

        public GenericRepository(ApplicationDBContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}