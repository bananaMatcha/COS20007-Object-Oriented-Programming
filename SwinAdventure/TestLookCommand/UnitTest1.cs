using SwinAdventure;
using System.Numerics;
namespace TestLookCommand
{
    public class Tests
    {

        Player player;
        LookCommand lookCommand;

        Inventory playerInventory;
        Item shovel;
        Item gem;
        Item book; 

        Bag bag;
        Location currentLocation;

        [SetUp]
        public void Setup()
        {
            player = new Player("Fred", "the mighty programmer");
            lookCommand = new LookCommand();
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            gem = new Item(new string[] { "gem" }, "a gem", "A bright green gem");
            book = new Item(new string[] { "book" }, "a book", "A book with red cover");

            playerInventory = player.Inventory;
            bag = new Bag(new string[] { "bag" }, "the bag", "this is the bag");


            currentLocation = new Location("current location", "this is the player's current location");
            currentLocation.Inventory.Put(book);
            currentLocation = player.Location;
           
        }

        [Test]
        public void TestLookAtMe()
        {
            string[] commandInput = { "look", "at", "inventory" };

            string result = lookCommand.Execute(player, commandInput);

            Assert.That("You are Fred, the mighty programmer.\nYou are carrying:\n", Is.EqualTo(result));
        }

        [Test]
        public void TestLookAtGem()
        { 
            playerInventory.Put(gem);
            
            string[] commandInput = { "look", "at", "gem" };

            string result = lookCommand.Execute(player, commandInput);
            Assert.That("A bright green gem", Is.EqualTo(result));
        }

        [Test]
        public void TestLookAtUnk() 
        {
            playerInventory.Put(bag);
            playerInventory.Put(shovel);

            string[] commandInput = { "look", "at", "gem" };

            string result = lookCommand.Execute(player, commandInput);
            Assert.That("I cannot find the gem in Fred", Is.EqualTo(result));
        }

        [Test]
        public void TestLookAtGemInMe() 
        {
            playerInventory.Put(gem);
            string[] commandInput = { "look", "at", "gem", "in", "inventory" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("A bright green gem", Is.EqualTo(result));
        }


        [Test]
        public void TestLookAtGemInBag()
        {
            playerInventory.Put(bag);
            bag.Put(gem);

            string[] commandInput = { "look", "at", "gem", "in", "bag" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("A bright green gem", Is.EqualTo(result));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {

            player.Inventory.Put(gem); // Add gem directly to player's inventory
            string[] commandInput = { "look", "at", "gem", "in", "bag" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("I cannot find the bag", Is.EqualTo(result));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            playerInventory.Put(bag);
            string[] commandInput = { "look", "at", "gem", "in", "bag" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("I cannot find the gem in the bag", Is.EqualTo(result));
        }

        [Test]
        public void TestInvalidCommand1()
        {
            //the 4th word must be "in"
            string[] commandInput = { "look", "at", "gem", "or", "pc" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("What do you want to look in?", Is.EqualTo(result));
        }

        [Test]
        public void TestInvalidCommand2()
        {
            //Test that the second word must be "at"
            string[] commandInput = { "look", "outside", "window"};
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("What do you want to look at?", Is.EqualTo(result));
        }

        [Test]
        public void TestInvalidCommand3()
        {
            //Test that the first word must be "look"
            string[] commandInput = { "glance", "at", "bag" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("Error in look input", Is.EqualTo(result));
        }

        [Test]
        public void TestInvalidCommand4()
        {
            //Command must have 3 or 5 elements
            string[] commandInput = { "helow", "world" };
            string result = lookCommand.Execute(player, commandInput);
            Assert.That("I don't know how to look like that", Is.EqualTo(result));
        }
    }
}