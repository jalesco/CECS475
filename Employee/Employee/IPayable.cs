using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSortProgram
{
    public interface IPayable
    {
        decimal GetPaymentAmount(); //no implementation, calculates payment
    }//end interface decleration
}//end namespace Employee
