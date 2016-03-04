using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Passed add and save changes");
        }// end Insert





    }// end class Repository
}
