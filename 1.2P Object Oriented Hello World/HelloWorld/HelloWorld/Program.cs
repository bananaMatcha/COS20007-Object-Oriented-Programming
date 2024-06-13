using System.Security.Cryptography.X509Certificates;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greeting from Message Objects.");
            // create list of messages
            List<Message> messages = new List<Message>();

                messages.Add(new Message("Hi Anna, How are you today?"));
                messages.Add(new Message("Hey Bob! How it's going?"));
                messages.Add(new Message("Good day Chloe! Have a nice day!"));
                messages.Add(new Message("What's up Dan. You good today?"));
                messages.Add(new Message("Hello Ethan! How have you been?"));

            
            Console.WriteLine("Enter a name:");
            string name = Console.ReadLine();
            if (name.ToLower() == "anna")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "bob")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "chloe")
            {
                messages[2].Print();
            }
            else if (name.ToLower() == "dan")
            {
                messages[3].Print();
            }
            else if (name.ToLower() == "ethan")
            {
                messages[4].Print();
            }
            else
            {
                myMessage.Print();
            }
        }
    }
}
