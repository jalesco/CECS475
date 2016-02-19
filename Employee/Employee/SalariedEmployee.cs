using System;

namespace EmployeeSortProgram
{
    class SalariedEmployee : Employee
    {
        private decimal WeeklySalary;

        //Constructor

        public SalariedEmployee(string fName, string lName, string ssNum, decimal salary) : base(fName, lName, ssNum) {
            WeeklySalary = salary;           
        }//end constructor

        //Property that gets or sets weekly salaries
        public decimal WeeklySalaries {
            get {
                return WeeklySalary;
            } //end get
            set {
                if (value >= 0)
                    WeeklySalary = value;
                else
                    throw new ArgumentOutOfRangeException("Weekly Salary: ", value, " must be greater than 0");
            } //end set
        }//end property WeeklySalaries

        public override decimal GetPaymentAmount()
        {
            return WeeklySalaries;
        }

        // return string representation of SalariedEmployee object
        public override string ToString()
        {
            return string.Format("Salaried employee: {0}\n{1}: {2:C}",
               base.ToString(), "Pay", GetPaymentAmount() + "\n");
        } // end method ToString  

    }//end SalariedEmployee
}//end namespace
