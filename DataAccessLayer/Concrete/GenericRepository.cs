using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public virtual void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(int id)
        {
            using (var context = new TContext())
            {
                var entityId = context.Set<T>().Find(id);
                context.Set<T>().Remove(entityId);
                context.SaveChanges();
            }
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(predicate);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                         ? context.Set<T>().ToList()
                         : context.Set<T>().Where(filter).ToList();
            }
        }

        public virtual T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public virtual void Update(T entity,int id)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
      
    }
}
