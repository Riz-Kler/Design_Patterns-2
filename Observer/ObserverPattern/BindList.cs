using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;


namespace ObserverPattern
{
    class Market // obervable collection
    {
        public BindingList<float> Prices = new BindingList<float>(); // change List to BindingList you don't need the even
        // notifications done automatically

        public void AddPrice(float price)
        {
            Prices.Add(price);
     //       PriceAdded?.Invoke(this, price);
        }

      //  public event EventHandler<float> PriceAdded;
    }

    static class BindList //  observer observs market collection
    {
        static void Main(string[] args)
        {
 //           var market = new Market();
 //           market.PriceAdded += (sender, f) => { WriteLine($"We have got a Market price of {f}"); };

 //           market.AddPrice(123);
 // //          System.Threading.Thread.Sleep(5555);
 //           market.AddPrice(556);
 // //          System.Threading.Thread.Sleep(5555);
 //           market.AddPrice(665);
 ////           System.Threading.Thread.Sleep(5555);
 //           market.AddPrice(666);
 ////           System.Threading.Thread.Sleep(5555);
 //           market.AddPrice(555);

            var market = new Market();

            // As market is now a BindingList then you have more options. ListChanged allows to do mroe
            market.Prices.ListChanged += (sender, eventArgs) =>
            {
                if (eventArgs.ListChangedType == ListChangedType.ItemAdded) //check if an item has been added
                {
                    float price = ((BindingList<float>) sender)[eventArgs.NewIndex];
                    WriteLine($"Binding list got a price of {price}");
                }
            }; 
                        market.AddPrice(556);
        }
    }
}
