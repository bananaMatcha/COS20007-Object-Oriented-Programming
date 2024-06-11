using System;

namespace Counter
{
    internal class Program
    {
        static private void PrintCounters(Counter[] counters) //take parameter as an array of the 'Counter' Class 
        {
            foreach (Counter counter in counters) // foreach (Counter myCounters[i] in myCounters) 
            {
                Console.WriteLine("{0} is {1}", counter.Name, counter.Ticks); //access Counter's properties
            }
        }

        static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3]; // declare an array with 3 items named 'myCounters'

            myCounters[0] = new Counter("Counter 1"); //declare Counter object has a name of "Counter 1"
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i = 1; i <= 9; i++)
            {
                myCounters[0].Increment(); 
            }

            for (int i = 1; i <= 14; i++)
            {
                myCounters[1].Increment();
            }

            PrintCounters(myCounters);
            myCounters[2].Reset(); //call Reset method from the Counter class

            PrintCounters(myCounters);

            Console.WriteLine("Press any key to exit..."); 
            Console.ReadKey(); // Wait for user input to exit
        }
    }
}
