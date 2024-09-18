using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UdemyMvcPortfolio.Models.Entity;

namespace UdemyMvcPortfolio.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCVEntities db = new DbCVEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }
        public void TUpdate(T entity)
        {
            db.SaveChanges();
        }
        public void TDelete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }
        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

    }
}