using System;
namespace EmployeeSortProgram
{
    class HourlyBaseEmployee: Employee
    {
        private decimal wage; // wage per hour
        private decimal hours; // hours worked for the week

        //Five-parameter constructor
        public HourlyBaseEmployee(string first, string last, string ssn, decimal hourlyWage, decimal workHours) : base(first, last, ssn) {
            wage = hourlyWage;
            hours = workHours;
        }//end constructor

        //Property that gets and sets hourly wage's employees (properties 
        public decimal Wage
        {
            get {
                return wage;
            }// end get

            set { //value is a keyword for the mutators that is 
                if (value >= 0)
                    wage = value;
                else
                    throw new ArgumentOutOfRangeException("Wage: ", value, "Wage is not valid wage value");
            }// end set
        }//end Wage property

        //Property that gets and sets the Hours
        public decimal Hour {
            get {
                return hours;
            }// end get
            set {
                if (value >= 0)
                    hours = value;
                else
                    throw new ArgumentOutOfRangeException("Hours: ", value, " Not a valid hours value");
            }// end set
        }//end property Hour

        public override decimal GetPaymentAmount() {
            if (hours <= 40)
                return Wage * Hour;
            else
                return (40 * Wage) + ((Hour - 40) * Wage * 1.5M);            
        }//end GetPayAmount()

        //OVERRIDE ToString() METHOD
        public override string ToString()
        {
            return "Hourly Base Employee: " + base.ToString() +"\nWage: " + Wage +"\n"+ "Hours: "+ Hour + "\n" +"Pay:"+ GetPaymentAmount() + "\n";
        }

        
        

    }// end class HourlyBaseEmployee
}//end namespace
