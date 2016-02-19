using System;

namespace BasicEvent {

    public delegate void EventHandler(string value); //Define delegate for event handler

    class EventPublisher
    {
        private string theVal;

        //DELCARE THE EVENT
        public event EventHandler valueChanged;

        public string Val {
            set {
                this.theVal = value;

                //When the value changes, fire the event
                this.valueChanged(theVal);
            }// end set
        } //end property Val

    } //end class EventPublisher


    class Program
    {
        static void Main(string[] args)
        {
            EventPublisher obj = new EventPublisher();
            //Method 1, add the class that is signaling the event 
            //I thiink this is the one that is actually firing the event (below statement)
          obj.valueChanged += obj_valueChanged; //adding the obj_valueChanged event as an event handler to the valueChanged event. This fires the event when value changes
          
            string str;
            do {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();

                if (!str.Equals("exit")) { 
                    obj.Val = str;
                }

            } while (!str.Equals("exit"));

            Console.WriteLine("Goodbye");
            Console.Read();

        }// end Main

        //Part of method 1, the method in charge of notifying about a change
        static void obj_valueChanged(string value) { //The method keeping track of the changing value
            Console.WriteLine("The value changed to {0}", value);
        }// end obj_valueChanged
    }// end class Program
}// end namespace
