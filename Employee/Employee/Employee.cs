using System;
using System.Collections.Generic;
namespace EmployeeSortProgram
{
    public abstract class Employee : IPayable, IComparable
    {

        public String FirstName { get; private set; } //read-only property that gets employee's first name
        public String LastName { get; private set; } ////read-only property that gets employee's last name
        public String ssNum { get; private set; } //read-only property that gets employee's first name

        //CONSTRUCTOR
        public Employee(String first, String last, String ssn)
        {
            FirstName = first;
            LastName = last;
            ssNum = ssn;
        }//end constructor


        //OVERRIDE OF ToString() method for formatting
        public override string ToString()
        {
            return string.Format("\nFirst Name: {0}\nLast Name: {1}\nSSN: {2}", FirstName, LastName, ssNum);
        }//end ToString()

        public abstract decimal GetPaymentAmount(); //abstract method to get payments of all Employees (and its derived classes)

        //ICOMPARABLE COMPARETO OVERRIDE
        // param obj: Object being compared
        int IComparable.CompareTo(Object obj)
        { //overwrite CompareTo and pass in ONE Object parameter
            Employee e = (Employee)obj;
            if (this.LastName.CompareTo(e.LastName) == 0) {
                return String.Compare(this.FirstName, e.FirstName);
            }
            return String.Compare(this.LastName, e.LastName);
        }//end CompareTo implementation



        //ICOMPARER public static method
         public static IComparer <IPayable> sortPay() { // the class type 
            return (IComparer <IPayable>)new sortPaymentDescending();
         } 
        //Implementation of the IComparer's Compare method
        private class sortPaymentDescending : IComparer <Object> //The type parameter refers to the parameter you will pass into the Compare function
        {
            int IComparer<Object>.Compare(Object o1, Object o2)
            {
                Employee e1 = (Employee)o1;
                Employee e2 = (Employee)o2;
                //The greater than means that whatever is on the LHS is 
                if (e1.GetPaymentAmount() < e2.GetPaymentAmount()) 
                    return 1;                
                if (e1.GetPaymentAmount() > e2.GetPaymentAmount())                
                    return -1;                
                else 
                    return 0;                
            } //end Compare
        }//end sortSSNDescending class

        //SELECTION SORT METHOD
        public static void selectSort(IPayable[] arr)
        {
            //pos_min is short for position of min
            int pos_min;
            IPayable temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set min position to current index in array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ((arr[j] as Employee).ssNum.CompareTo((arr[pos_min] as Employee).ssNum) < 0)
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }//end for loop (i)
        }//end selection sort function
    }// end class Employee
} //end namespace
