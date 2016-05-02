using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWPF
{
    interface IRepository <T>
    {
        void Insert(T entity);
    }//end interface
}//end namespace
