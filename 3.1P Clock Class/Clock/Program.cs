namespace Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock myClock = new Clock();


            Console.WriteLine("Enter the number of ticks:");
            int n = int.Parse(Console.ReadLine()); //.Parse convert a String into a Number

            for (int i = 0; i <= n; i++)
            {
                myClock.Ticks();
                Console.WriteLine(myClock.DisplayTime());
            }
            myClock.Reset();

            Console.WriteLine("Reset clock:");
            Console.WriteLine(myClock.DisplayTime());

        }
    }
}
