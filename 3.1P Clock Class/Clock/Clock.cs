using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
        private Counter _hour;
        private Counter _minute;
        private Counter _second;

        public Clock()
        {
            _hour = new Counter("Hours");
            _minute = new Counter("Minutes");
            _second = new Counter("Seconds");
        }

        public void Ticks()
        {
            _second.Increment();
            if (_second.Ticks == 60)
            {
                _minute.Increment();
                _second.Reset();
            }
            if (_minute.Ticks == 60)
            {
                _hour.Increment();
                _minute.Reset();
            }
            if (_hour.Ticks == 24)
            {
                _hour.Reset();
            }
        }

        public void Reset() 
        {
            _hour.Reset();
            _minute.Reset();
            _second.Reset();
        }

        public string DisplayTime()
        {            
            return String.Format("{0:D2}:{1:D2}:{2:D2}", _hour.Ticks, _minute.Ticks, _second.Ticks);            
        }


    }
}
