using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class Repository <T> : IRepository<T> where T: class
    {
        private   DbContext context;
        protected DbSet<T>  set;

        public Repository(DbContext datacontext) {
            set = datacontext.Set<T>();
        }//end constructor

        public void Insert(T entity) {
            using (context = new SchoolDBEntities())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }      
            Console.WriteLine("Added and saved");
        }// end Insert

        public void Delete(T entity) {
            using (context = new SchoolDBEntities())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
                Console.WriteLine("Removed record.");
            
        }// end Delete

        public void Update(T entity) {
            using (context = new SchoolDBEntities())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
                Console.WriteLine("Updated.");            
        }//end Update

        public IEnumerable<T> GetAll() {
            return set;
        }//end GetAll()

        public T GetByID(int id) {
            return set.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return set.Where(predicate);
        }


        //parameter for the method is navigationProperties array, however the only thing being passed in is the lambda expression.
        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new SchoolDBEntities())
            {
                IQueryable<T> dbQuery = set;
                //Applying eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
                item = dbQuery.AsNoTracking().FirstOrDefault(where);//Don't track any changes for the selected item 
            }
            return item;
        }//end GetSingle
    }// end class Repository


    public interface IStandardRepository : IRepository<Standard>
    {
        
    }

    public interface IStudentRepository : IRepository<Student>
    {

    }

    public class StandardRepository : Repository <Standard>, IStandardRepository
    {
        public StandardRepository() : base(new SchoolDBEntities()) 
        {
            
        } //end constructor
        
    }//end class StandardRepository

    public class StudentRepository : Repository <Student>,IStudentRepository
    {
        public StudentRepository() : base(new SchoolDBEntities()) {
            
        }
    }//end class StudentRepository

}// end namespace
