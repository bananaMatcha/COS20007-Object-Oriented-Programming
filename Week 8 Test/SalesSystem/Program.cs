namespace SalesSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sales sales = new Sales();
            
            //create 2 batch orders
            Batch batch1 = new Batch("#1924x00001", "Sci-fi Books ");
            batch1.Add(new Transaction("#1","The Martian", 67.90m)); //using suffix 'm' to tell the
                                                                      //compiler this is decimal value
                                                                      //otherwise, compiler understands 67.90 as float/double
            batch1.Add(new Transaction("#2","Snow Crash", 44.10m));
            batch1.Add(new Transaction("#3","The War of the Worlds", 119.75m));

            Batch batch2 = new Batch("#1999x00002", "Fantasy Books");
            batch2.Add(new Transaction("#00-0001", "Compilers", 134.60m));
            batch2.Add(new Transaction("#10-0003", "Hunger Games 1-3", 45.00m));
            batch2.Add(new Transaction("#15-0020", "Learning Blender", 56.90m));
            
            //This batch is empty
            Batch batch3 = new Batch("#2111X00021", "Oxford Dictionary");

            //create nested batch order.
            Batch batch4 = new Batch("#Nested Batch", "Harry Potter the series");
            batch4.Add(new Transaction("#102", "Harry Potter and the Philosopher's Stone", 80.00m));
            batch4.Add(new Transaction("#106", "Harry Potter and the Goblet of Fire", 92.74m));
            batch1.Add(batch4);

            //create single transactions
            Transaction transaction1 = new Transaction("#25-0001", "GOSU tutorials", 89.99m);
            Transaction transaction2 = new Transaction("#25-0002", "OOP in C# for dummies", 29.99m);

            //add orders to Sales
            sales.Add(batch1);
            sales.Add(batch2);
            sales.Add(batch3);
            sales.Add(transaction1);
            sales.Add(transaction2);
             
            //print orders
            sales.PrintOrders();
        }
    }
}
