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



    }// end interface
}// end namespace
