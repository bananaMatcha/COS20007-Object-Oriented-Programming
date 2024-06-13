using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    public class Sales
    {
        private List<Thing> _orders;

        public Sales()
        {
            _orders = new List<Thing>();
        }

        public void Add(Thing order)
        {
            _orders.Add(order);
        }

        public void PrintOrders()
        {
            if (_orders.Count == 0)
            {
                Console.WriteLine("Order is empty.");
            }
            else
            {
                decimal totalSales = 0;

                Console.WriteLine("Sales:");
                foreach (Thing order in _orders)
                {
                    order.Print();
                    totalSales += order.Total();
                }

                Console.WriteLine($"    Sales Total: ${totalSales}");
            }
        }
    }
}
