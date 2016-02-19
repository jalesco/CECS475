using System;
namespace EmployeeSortProgram
{
    class BasePlusCommissionEmployee: CommissionEmployee
    {
        private decimal baseSalary;

        //Constructor
        public BasePlusCommissionEmployee(string first, string last, string ssn,
            decimal sales, decimal rate, decimal salary) : base(first, last, ssn, sales, rate)
        {
            baseSalary = salary; //valid base salary 
        }//end constructor

        //Property that gets and sets base salary employees
        public decimal BaseSalary {
            get {
                return baseSalary;
            }//end get

            set {
                if (value >= 0)                
                    baseSalary = value;                
                else 
                    throw new ArgumentOutOfRangeException("Base salary: ", value, " must be greater than 0");
            }//end set
        }//end property

        //Calculate earnings of BasePlusCommissionEmployees
        public override decimal GetPaymentAmount()
        {
            return BaseSalary + base.GetPaymentAmount();
        }//end GetPaymentAmount()

        // return string representation of BasePlusCommissionEmployee object
        public override string ToString()
        {
            return "Base-Plus-Commission Employee:" + base.ToString() + "\n";
        } // end method ToString  

    }//end class
}//end namespace
