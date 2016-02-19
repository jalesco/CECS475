using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSortProgram
{
    class CommissionEmployee: Employee
    {
        private decimal grossSales; //gross weekly sales
        private decimal commissionRate; //commission percentage

        //Constructor
        public CommissionEmployee(string first, string last, string ssn,
            decimal sales, decimal rate) : base(first, last, ssn)
        {
            grossSales = sales;
            commissionRate = rate;
        }//end constructor

        //Property that gets a commission employee's gross sales
        public decimal GrossSales {
            get {
                return grossSales;
            }//end get
            set {
                if (value >= 0)
                    grossSales = value;
                else
                    throw new ArgumentOutOfRangeException("Gross sales amount must be >= 0");
            }//end set                        
        }//endn property GrossSales


        //Property that gets the commission rate

        public decimal CommissionRate {
            get {
                return commissionRate;
            }//end get

            set {
                if (value > 0 && value < 1)
                {
                    commissionRate = value;
                }
                else {
                    throw new ArgumentOutOfRangeException("Commission rate must be between 0 and 1");
                }
            }//end set

        }//end property CommissionRate

        //Returns the amount a CommissionEmployee made
        public override decimal GetPaymentAmount()
        {
            return CommissionRate * GrossSales;
        }//end function GetPaymentAmount()

        //Override ToString() for CommissionEmployees
        public override string ToString()
        {
            return base.ToString() + "\nGross Sales: " + GrossSales + "\nCommission Rate: " + CommissionRate + "\n" + "Pay: " + GetPaymentAmount() + "\n";
        }


    }//end class
}//end namespace
