using SwinAdventure;
namespace TestBag
{
    public class Tests
    {

        Item shovel;
        Item sword;
        Item pc;

        Bag myBag = new Bag(new string[] { "bag1", "inventory" }, "my bag", "This is my bag");

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a bronze sword");
            pc = new Item(new string[] { "pc" }, "a computer", "This is a computer");

            myBag.Put(shovel);
            myBag.Put(pc);
        }

        [Test]
        public void TestBagLocatesItem()
        {            
            GameObject myPc = myBag.Locate("pc");

            Assert.IsNotNull(myPc);
            Assert.IsTrue(myBag.Inventory.HasItem("pc"));
        }

        [Test]
        public void TestBagLocatesitself()
        {          
            bool self = myBag.AreYou("bag1");

            Assert.IsNotNull(self);
            Assert.That(self, Is.True);
           
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            GameObject notInBag = myBag.Locate("sword");

            Assert.IsNull(notInBag);
           // Assert.IsFalse(myBag.Inventory.HasItem("sword"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            string actual = myBag.FullDescription;
            string expectedString = "In the my bag you can see:\na shovel (shovel)\na computer (pc)\n";

            Assert.That(expectedString, Is.EqualTo(actual));
        }

        [Test]
        public void TestBagInBag() 
        {
            Bag anotherBag = new Bag(new string[] { "bag2" }, "bag 2", "This is another bag");

            myBag.Put(anotherBag); //bag 2 is an object of Item => can be put in an inventory 

            GameObject bag2Located = myBag.Locate("bag2");

            Assert.IsNotNull(bag2Located);

            //test bag1 can locate bag2
            Assert.IsTrue(myBag.Inventory.HasItem("bag2"));

            // Test that bag1 can locate other items in bag1
            Assert.IsTrue(myBag.Inventory.HasItem("shovel"));

            Item book = new Item(new string[] {"book" }, "a book", "This is a book");

            anotherBag.Put(book);

            GameObject inBag2 = myBag.Locate("book");

            // Test that bag1 can not locate items in bag2.

            Assert.IsNull(inBag2);
            Assert.IsFalse(myBag.Inventory.HasItem("book"));
        }

    }

}