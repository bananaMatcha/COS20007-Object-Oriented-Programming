using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Counter
{
    public class Counter
    {
        private string _name;
        private int _count;

        public string Name //property
        {
            get 
            { 
                return _name; 
            }
            set 
            {
                _name = value; 
            }
        }

        public int Ticks
        {
            get
            {
                return _count;
            }
        }

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
             _count = 0;
        }

       

    }
}
