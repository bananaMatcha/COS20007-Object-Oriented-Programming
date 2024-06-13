using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    public class Transaction : Thing
    {
 
        private decimal _amount;

        public Transaction(string number, string name, decimal amount) : base(number, name) 
        {
            _amount = amount;
        }

        public override void Print() 
        {
            Console.WriteLine($"{Number}, {_name}, ${Total()}");
        }
        public override decimal Total()
        {
            return _amount;
        }    
    }
}
