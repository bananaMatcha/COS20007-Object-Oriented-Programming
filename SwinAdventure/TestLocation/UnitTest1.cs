using SwinAdventure;
namespace TestLocation
{
    public class Tests
    {

        Location location;
        Item item;

        [SetUp]
        public void Setup()
        {
            location = new Location("Hallway", "a long corridor");
            item = new Item(new string[] { "gem" }, "a gem", "A bright green gem");
            //put item in the Location's Inventory           
            location.Inventory.Put(item);
        }

        [Test]
        public void TestLocationIdentifiesThemselves()
        {
         
            Assert.IsTrue(location.AreYou("room"));
            Assert.IsTrue(location.AreYou("here"));
            Assert.IsFalse(location.AreYou("Backyard"));
        }

        [Test]
        public void TestLocationLocateItems()
        {
            Assert.That(item, Is.SameAs(location.Locate("gem")));
            Assert.IsNull(location.Locate("chair"));
        }

        [Test]
        public void TestPlayerLocateItemsInLocation()
        {
            Player player = new Player("Han", "a cool coder");
            player.Location = location;

            Assert.That(item, Is.SameAs(player.Locate("gem")));
            Assert.IsNull(player.Locate("chair"));
        }


    }
}