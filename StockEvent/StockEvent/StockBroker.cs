using System;
using System.Collections.Generic;


namespace StockEvent
{
    class StockBroker
    {
        private string brokerName;
        private List<Stock> stocks;

        public StockBroker(string name) {
            brokerName = name;
            stocks = new List<Stock>();
        }

        public string BrokerName {
            get { return brokerName; }
            set { this.brokerName = value; }
        }

        //Adds the specific Stock to the StockBroker's 
        public void AddStock(Stock stock) {
            stocks.Add(stock);
                lock(stock)
                {
                    stock.notification += BrokerEventHandler; //Event that displays the info to the console
                }
                
                lock(stock)
                {
                    stock.notification += WriteBrokerFile; //Event that writes the stock to the file  
                }                               
        }// end AddStock

        public override string ToString()
        {
            return "Broker Name: " + brokerName;
        }


        //The StockBroker event handler that displays the broker and stock information 
        void BrokerEventHandler(object sender, EventData e) {
            Console.WriteLine("Broker Name: {0}  Stock name: {1}  Current value: {2} Number of Changes: {3}", BrokerName, e.stockName, e.currentValue, e.changes) ;
        }// end BrokerEventHandler

        //The StockBroker eventHandler
        void WriteBrokerFile(object sender, EventData e) {            
            string text = "Broker name: " + BrokerName + " Stock Name: " + e.stockName + " Current Value: " + e.currentValue + " Number of Changes: " + e.changes + "\n";            
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\jalex_000\Desktop\CECS475\StockEvent\StockEvent\stocks.txt", true);
            file.WriteLine(text);
            file.Close();
        }// end WriterBrokerFile
    }//end class
}//end namespace
