using System;

namespace EmployeeSortProgram
{

    public delegate void sortDelegate(IPayable[] p); //DELEGATE DECLERATION

    class Program
    {
        


        static void Main(string[] args)
        {
            
            string sMenuInput; // string version of input
            int menuInput; //int for menu input
            bool menu = true; //boolean to keep the menu going
            IPayable [] payableObjects = new IPayable[8];
            Action<IPayable[]> sort;
            payableObjects[0] = new SalariedEmployee("John", "Smith", "111-11-1111", 700M);
            payableObjects[1] = new SalariedEmployee("Antonio", "Smith", "555-55-5555", 800M);
            payableObjects[2] = new SalariedEmployee("Victor", "Smith", "444-44-4444", 600M);
            payableObjects[3] = new HourlyBaseEmployee("Karen", "Price", "222-22-2222", 16.75M, 40M);
            payableObjects[4] = new HourlyBaseEmployee("Ruben", "Zamora", "666-66-6666", 20.00M, 40M);
            payableObjects[5] = new CommissionEmployee("Sue", "Jones", "333-33-3333", 10000M, .06M);
            payableObjects[6] = new BasePlusCommissionEmployee("Bob", "Lewis", "777-77-7777", 1000M, .04M, 250M);
            payableObjects[7] = new BasePlusCommissionEmployee("Lee", "Duarte", "888-88-888", 200M, .04M, 300M);
            

            //MAIN MENU LOOP

            do {
                Console.WriteLine("1. Sort by ascending order last names (IComparable)\n2. Sort payment amounts in decending order\n" +
                                 "3. Sort SSNs by ascending order\n4. Quit");
                sMenuInput = Console.ReadLine();
                menuInput = Int32.Parse(sMenuInput);
                switch (menuInput)
                {
                    case 1: //SORT LAST NAME IN ASCENDING ORDER USING IComparable
                        Array.Sort(payableObjects); //Calls IComparable's CompareTo method
                        foreach (IPayable i in payableObjects) {
                            Console.WriteLine((i as Employee).FirstName + " " + (i as Employee).LastName);
                        } // end for-each loop for ascending order (last names)
                        break;
                    case 2: //SORT PAY IN DESCENDING ORDER USING IComparer
                        Array.Sort(payableObjects, Employee.sortPay()); //Calls IComparer's Compare method
                        foreach (IPayable i in payableObjects) {
                            Console.WriteLine((i as Employee).FirstName + " " + (i as Employee).LastName + " " + (i as Employee).GetPaymentAmount());
                        }// end foreach loop                        
                        break;
                    case 3: //SORT SSN IN ASCENDING ORDER USING DELEGATE AND SELECTION SORT
                            //sortDelegate s = selectSort; // Delegate instantiation, points to selection sort
                            // s(payableObjects); // pass in payableObjects array into delegate
                        sort = Employee.selectSort;
                        foreach (IPayable i in payableObjects) {
                            Console.WriteLine((i as Employee).FirstName + " " + (i as Employee).LastName + " " + (i as Employee).ssNum);
                        }                        
                        break;
                    case 4: //Quits program 
                        Console.WriteLine("Thank you for using this program.");
                        menu = false;
                        break;                
                }//end switch            
            } while (menu);            
            Console.Read();
        }//end main
    }//end class Program
}// end namespace declaration 
