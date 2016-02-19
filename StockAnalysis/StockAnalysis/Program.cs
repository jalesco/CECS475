using System;
using System.Collections.Generic;
using System.Threading;
namespace StockAnalysis
{
    class StockBroker
    {
        private string brokerName;
        private List<Stock> brokerStocks;

        //Event decleration
        public event EventHandler notify;


        public StockBroker(string name)
        {
            brokerName = name;
            brokerStocks = new List<Stock>();
        }


        public string BrokerName
        {
            get
            {
                return BrokerName;

            }

            set
            {
                this.brokerName = value;
            }
        }//end BrokerName property

        public List<Stock> StockList
        {
            get
            {
                return brokerStocks;
            }
        }// end property StockList


        //Adds stocks to a broker's stock list
        public void AddStock(Stock stock)
        {
            this.brokerStocks.Add(stock);
            //EVENT GOES HERE
            stock.stockEvent += EventHandler(stock.StockName, stock.CurrentStockValue, stock.NumberOfChanges);            
        }//end AddStock function
    }// end class StockBroker


    class Stock
    {
        private string sName;
        private int initVal;
        private int maxChange;
        private int threshold;
        private int currentValue;
        private int numberOfChanges;
        private Thread start;

        public delegate void StockNotfication(string stockName, int currentValue, int numberOfChanges); //event delegate decleration

        public event StockNotfication stockEvent;// event decleration

        //will need a file save notification event


        //Constructor


        public Stock(string name, int startingVal, int max, int t)
        {
            sName = name;
            initVal = startingVal;
            currentValue = initVal;
            maxChange = max;
            threshold = t;
            numberOfChanges = 0;
            //May need to incorporate the thread
            start = new Thread(new ThreadStart(Activate));
        }// end constructor


        public string StockName
        {
            get
            {return sName;}

            set
            {
                this.sName = value;
            }
        }// end property

        public int InitialValue
        {
            get
            {
                return initVal;
            }

            set
            {
                initVal = value;
            }
        }// end InitialValue

        public int MaxChange
        {
            get
            {
                return maxChange;
            }

            set
            {
                maxChange = value;
            }
        }// end property MaxChange

        public int Threshold
        {
            get
            {
                return threshold;
            }

            set
            {
                threshold = value;
            }

        }// end Threshold

        public int CurrentStockValue
        {
            get
            {
                return currentValue;
            }
        }

        public int NumberOfChanges
        {
            get { return numberOfChanges; }
        }

        public void Activate()
        {
            for (;;)
            {
                Thread.Sleep(1);
                ChangeStockValue();
            }
        }//end Activate()

        public void ChangeStockValue()
        {
            //UPDATE (numberChanges)
            Random random = new Random();
            currentValue += random.Next(0, maxChange + 1);
            this.numberOfChanges++;
            //Event gets raised here
            if (currentValue - initVal > threshold)
            {
                this.stockEvent(sName, currentValue, this.numberOfChanges);
            }//end event fire
        }//end ChangeStockValue()


        public override string ToString()
        {
            return "Stock: " + StockName + "   " + "Current value: " + CurrentStockValue + "   " + "Number of changes: " + NumberOfChanges;
        }


    }//end class Stock



    public class EventData : EventArgs
    {
        public string stockName { get; set; }
        public int currStockValue { get; set; }
        public int changes { get; set; }
    } //end EventData



    class Program
    {
        static void Main(string[] args)
        {
            List <Stock> stockList = new List<Stock> ();
            Stock stock1 = new Stock("Technology", 160, 5, 15);
            Stock stock2 = new Stock("Retail", 30, 2, 6);
            Stock stock3 = new Stock("Banking", 90, 4, 10);
            Stock stock4 = new Stock("Commodity", 500, 20, 50);


            StockBroker b1 = new StockBroker("Broker 1");
            b1.AddStock(stock1);
            b1.AddStock(stock2);

            StockBroker b2 = new StockBroker("Broker 2");
            b2.AddStock(stock1);
            b2.AddStock(stock3);
            b2.AddStock(stock4);

            StockBroker b3 = new StockBroker("Broker 3");
            b3.AddStock(stock1);
            b3.AddStock(stock3);

            StockBroker b4 = new StockBroker("Broker 4");
            b4.AddStock(stock1);
            b4.AddStock(stock2);
            b4.AddStock(stock3);
            b4.AddStock(stock4);

            //Need to toggle the event listener

            foreach (Stock s in b4.StockList) {
                Console.WriteLine(s);
            }

            Console.Read();


        }// end Main




    }// end class Program
}// 
