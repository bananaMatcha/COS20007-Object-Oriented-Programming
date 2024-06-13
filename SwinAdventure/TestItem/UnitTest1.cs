using SwinAdventure;
namespace TestItem
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        { }
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");

        [Test]
        public void TestIdentifiableItem()
        {
            bool IsShovel = shovel.AreYou("shovel"); ;
            Assert.IsTrue(IsShovel, "shovel");
        }

        [Test]
        public void TestShortDescription()
        {
            string shortDesc = shovel.ShortDescription;
            Assert.That(shortDesc, Is.EqualTo("a shovel (shovel)"));
        }

        [Test]
        public void TestFullDescription()
        {
            string fullDesc = shovel.FullDescription;
            Assert.That(fullDesc, Is.EqualTo("This is a shovel"));
        }
    }
}