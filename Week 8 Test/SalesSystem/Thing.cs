using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    public abstract class Thing
    {
        protected string _number;
        protected string _name;

        public Thing (string number, string name)
        {
            _number = number;
            _name = name;
        }

        public abstract void Print();
        public abstract decimal Total();

        public string Number
        {
            get { return _number; }
        }
        public string Name
        {
            get { return _name; }
        }
    }
}
