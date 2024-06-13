using SwinAdventure;
namespace TestPlayer
{
    public class Tests
    {
        Player player = new Player("Fred", "the mighty programmer");
        Inventory playerInventory = new Inventory();

        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a bronze sword");

        Location location1 = new Location("current location", "This is player's location");
 
        [SetUp]
        public void Setup()
        {
            playerInventory = player.Inventory;
            playerInventory.Put(shovel);
            location1 = player.Location;
        }

        [Test]
        public void TestIdentifiablePlayer()
        {
            bool PlayerId1 = player.AreYou("me");
            bool PlayerId2 = player.AreYou("inventory");

            Assert.That(PlayerId1, Is.True);
            Assert.That(PlayerId2, Is.True);    
        }

        [Test]
        public void TestPlayerLocatesItems() 
        {
            GameObject itemLocated = player.Locate("shovel");
            Assert.That(itemLocated, Is.EqualTo(shovel));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            GameObject self = player.Locate("me");
            GameObject owns = player.Locate("inventory");

            Assert.That(self, Is.EqualTo(player));
            Assert.That(owns, Is.EqualTo(player));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            GameObject notOwned = player.Locate("book");
            Assert.That(notOwned, Is.Null);
        }
       
        [Test]
        public void TestPlayerFullDescription()
        {
            Player testplayer = new Player("Bob", "the happy programmer");
            testplayer.Inventory.Put(new Item(new string[] { "shovel" }, "a shovel", "This is a shovel"));
            testplayer.Inventory.Put(new Item(new string[] { "pc" }, "a computer", "This is a small computer"));

            string expected = "You are Bob, the happy programmer.\nYou are carrying:\na shovel (shovel)\na computer (pc)\n";
            Assert.That(expected, Is.EqualTo(testplayer.FullDescription));
        }
    }  
}