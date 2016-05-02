using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository <T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetByID(int id);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);


    }// end interface
}// end namespace
