using SwinAdventure;
using System.Numerics;

namespace TestCommandProcessor
{
    public class Tests
    {
        Player player;
        CommandProcessor processor;
        

        Inventory playerInventory;
        Item shovel;
        Item gem;

        [SetUp]

        public void Setup()
        {
            player = new Player("Fred", "the mighty programmer");

            processor = new CommandProcessor();
            processor.AddCommand(new LookCommand());
            processor.AddCommand(new MoveCommand());

            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            gem = new Item(new string[] { "gem" }, "a gem", "A bright green gem");

            playerInventory = player.Inventory;
            playerInventory.Put(shovel);

            Location location1 = new Location("First location", "This is the first location");
            Location location2 = new Location("Second location", "This is the second location");

            SwinAdventure.Path toPath1 = new SwinAdventure.Path(new string[] { "north" }, "First path", "a path leading to the first location", location1);
            SwinAdventure.Path toPath2 = new SwinAdventure.Path(new string[] { "south" }, "Second path", "a path leading to the second location", location2);

            location2.AddPath(toPath1);
            location1.AddPath(toPath2);
            player.Location = location1;
        }

        //check look command
        [Test]
        public void TestLookAtMe()
        {

            string[] commandInput = { "look", "at", "me" };

            string result = processor.CallCommand(player, commandInput);

            Assert.That("You are Fred, the mighty programmer.\nYou are carrying:\na shovel (shovel)\n", Is.EqualTo(result));
        }
        //check invalid look command
        [Test]
        public void TestLookAtGem()
        {

            string[] commandInput = { "look"};

            string result = processor.CallCommand(player, commandInput);

            Assert.That("I don't know how to look like that", Is.EqualTo(result));
        }

        //check valid move command
        [Test]
        public void TestMoveToValidDestination()
        {

            string[] commandInput = { "move", "south" };

            string result = processor.CallCommand(player, commandInput);

            // Update the assertion to match the expected output
            Assert.That( $"\nYou are moving towards Second path.\nYou travel through a path leading to the second location.\nYou have arrived at the Second location." +
                $" \n\nYou are at Second location.\nRoom Description: This is the second location.\nPaths that you can go to:\nnorth\n\nIn this room, you can see: ", Is.EqualTo(result));
        }
        //check invalid move command 
        [Test]
        public void TestMoveToInvalidDestination()
        {

            string[] commandInput = { "move", "northwest" };

            string result = processor.CallCommand(player, commandInput);

            // Update the assertion to match the expected output
            Assert.That("Could not find the path ", Is.EqualTo(result));
        }

        [Test]
        public void TestNotCommand()
        {
            string[] commandInput = { "fly", "north" };

            string result = processor.CallCommand(player, commandInput);

            // Update the assertion to match the expected output
            Assert.That(result, Is.Null);
        }
    }
}