using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {   
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        void Create(T entity);
        void Update(T entity ,int id);
        void Delete(int id);
    }
}
