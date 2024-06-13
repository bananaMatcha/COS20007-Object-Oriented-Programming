using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    public class Batch : Thing
    {
  
        private List<Thing> _items;

        public Batch(string number, string name) : base (number, name)
        {
            _items = new List<Thing>();
        }

        public void Add(Thing item)
        {
            _items.Add(item);
        }
        public override void Print()
        {
            Console.WriteLine($"Batch sale: {Number}, {Name}");
            if (_items.Count > 0)
            {
                foreach (Thing item in _items)
                {
                    item.Print();

                }
                Console.WriteLine($"    Total: ${Total()}");
            }
            else
            { 
                Console.WriteLine("Empty Order.");
            }         
        }
        public override decimal Total()
        {
            decimal _total = 0;
            foreach (Thing item in _items)
            {
                _total += item.Total();
            }
            return _total;
        }
    }
}
