using SwinAdventure;
namespace TestInventory
{
    public class Tests
    {
        Inventory myInventory = new Inventory();
        Item shovel;
        Item sword;
        Item pc; 

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a bronze sword");
            pc = new Item(new string[] { "pc" }, "a computer", "This is a computer");

            myInventory.Put(shovel);
            myInventory.Put(sword);
        }

        [Test]
        public void TestFindItem()
        {
            bool itemFound = myInventory.HasItem("shovel"); 
            Assert.IsTrue(itemFound);          
        }

        [Test]
        public void TestNoItemFound() 
        {
            bool itemNotFound = myInventory.HasItem("pc");
            Assert.IsFalse(itemNotFound);
        }

        [Test]
        public void TestFetchItem() 
        {
            Item fetchedItem = myInventory.Fetch("shovel");

            Assert.IsNotNull(fetchedItem);
            Assert.IsTrue(myInventory.HasItem("shovel")); //item still remains in the inventory
        }

        [Test]
        public void TestTakeItem()
        {
            Inventory theInventory = new Inventory();
            theInventory.Put(shovel);
            theInventory.Take(shovel.FirstId);
            Assert.IsFalse(theInventory.HasItem(shovel.FirstId));
        }

        [Test]        
        public void TestItemList()
        {
            Inventory testInventory = new Inventory();
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a bronze sword");

            testInventory.Put(shovel);
            testInventory.Put(sword);
            
            string expectedItemList = "a shovel (shovel)\na bronze sword (sword)\n";

            string itemList = testInventory.ItemList;

            Assert.That(expectedItemList, Is.EqualTo(itemList));
        }
    }
}