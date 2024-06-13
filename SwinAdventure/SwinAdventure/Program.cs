using System.Numerics;

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //get player name and description from user 
            Console.WriteLine("Enter player's name: ");
            string playerName = Console.ReadLine();


            Console.WriteLine("Enter player's description: ");
            string playerDesc = Console.ReadLine();


            //assign user input into new Player
            Player _player = new Player(playerName, playerDesc);

            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item pc = new Item(new string[] { "pc" }, "a computer", "This is a small computer");


            Inventory playerInventory = new Inventory();
            playerInventory = _player.Inventory;

            playerInventory.Put(shovel);
            playerInventory.Put(pc);

            Bag playerBag = new Bag(new string[] {"bag"}, "the bag", "This is your bag");
            playerInventory.Put(playerBag);

            Item diamond = new Item(new string[] { "diamond" }, "a blue diamond", "This is a blue diamond");
            playerBag.Put(diamond);


            // W7.2
            // Create locations
            Location hallway = new Location("Hallway", "a long corridor");
            Location garden = new Location("Garden", "a big garden at the backyard");
            Location darkRoom = new Location("Dark room", "a mysterious room with no lights");

            // Create paths between locations
            Path pathToGarden = new Path(new string[] { "north" }, "Garden Path", "a path leading to the garden", garden);
            Path pathToHallway = new Path(new string[] { "south" }, "Hallway Path", "a path leading back to the hallway", hallway);
            Path pathToDarkRoom = new Path(new string[] { "west" }, "Dark Room Path", "a path leading to the dark room", darkRoom);

            // Add paths to locations
            hallway.AddPath(pathToGarden);
            garden.AddPath(pathToHallway);
            garden.AddPath(pathToDarkRoom);
            darkRoom.AddPath(pathToGarden);

            //create more items
            Item painting = new Item(new string[] { "painting" }, "a beautiful painting", "A landscape painting");
            Item book = new Item(new string[] { "book" }, "a red book", "This is a red book written in greek");

            // Add items to the location
            hallway.Inventory.Put(painting);
            darkRoom.Inventory.Put(book);

            // Set the player's initial location
            _player.Location = hallway;
            // Display the initial location description
            // Console.WriteLine(player.Location.FullDescription);

            //set up playing mode is true
            bool playing = true;

            //create a Command Processor
            CommandProcessor processor = new CommandProcessor();

            //add allowed commands to the Processor
            processor.AddCommand(new LookCommand());
            processor.AddCommand(new MoveCommand());

            //Loop reading commands from the user, and getting the look command to execute them
            while (playing)
            {
                Console.WriteLine("Type your command here (enter 'exit' to end): ");
                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    playing = false;
                }
                string[] commandSplit = command.Split(' ');
                Console.WriteLine(processor.CallCommand(_player, commandSplit));

            }
        }
    }
}
