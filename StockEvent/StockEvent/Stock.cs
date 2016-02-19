using System;
using System.Threading;

namespace StockEvent
{
    class Stock
    {
        private string stockName; //stock's name
        private int initialValue;
        private int maxChange;
        private int threshold;
        private int currentValue;
        private int numberOfChanges;
        private Thread thread;
        private Random ran;

        //NO DELEGATE DECLERATION

        //EVENT DECLERATION
        public event EventHandler<EventData> notification; //it's an event that takes in an object sender and an EventArgs object (or a class that inherits from EventArgs)



        public Stock(string name, int initVal, int max, int t) {
            stockName = name;
            initialValue = initVal;
            max = maxChange;
            threshold = t;
            currentValue = initialValue;
            numberOfChanges = 0;
            ran = new Random();
            thread = new Thread(new ThreadStart(Activate));
            thread.Start();
        }//end constructor




        public void Activate()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                ChangeStockValue();
            }
        }//end Activate()

        public void ChangeStockValue() {
            //UPDATE STOCK VALUE
            currentValue += ran.Next(1, this.maxChange + 1);
            numberOfChanges++;

            //RAISE STOCK EVENT WHILE THE THRESHOLD HAS NOT BEEN REACHED
            if ((currentValue - initialValue) > threshold)
            {
                EventData args = new EventData();
                args.stockName = this.stockName;
                args.currentValue = this.currentValue;
                args.changes = this.numberOfChanges;
                OnNotification(args); //THIS IS THE LINE THAT RAISES THE EVENT

            }
        }//end ChangeStockValue

        //Invokes the event, called whenever the stock changes
        protected virtual void OnNotification(EventData e) {
            EventHandler<EventData> handler = notification;
            if (handler != null) {
                handler(this, e);
            }
        }//end StockChangeReached


    }//end class Stock
    
    //Class that takes in the data to pass the data elsewhere
    public class EventData : EventArgs {
        public string stockName { get; set; }
        public int currentValue { get; set; }
        public int changes { get; set; }
    }
}//end namespace
