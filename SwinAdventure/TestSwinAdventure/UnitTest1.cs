using SwinAdventure;
//using TestSwinAdventure;
namespace TestSwinAdventure
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {   
            
        }

        //Arrange
         IdentifiableObject myObject = new IdentifiableObject(new string[] { "fred", "bob" });

        [Test]
        public void TestAreYou()
        {  
            // Act
            bool isFred = myObject.AreYou("fred");
            bool isBob = myObject.AreYou("bob");
            Assert.IsTrue(isBob, "bob");   
            // Assert
            Assert.IsTrue(isFred, "fred");
           
        }

        [Test]
        public void TestNotAreYou()
        {
            bool notFred = myObject.AreYou("frank");

            Assert.IsFalse(notFred, "fred");
        }

        [Test]
        public void TestCaseSensitive() 
        {
            bool notlowerBob = myObject.AreYou("bOb");

            Assert.IsTrue(notlowerBob, "bob");
        }

        [Test]
        public void TestFirstId()
        {
            string actualFirstId = myObject.FirstId;

            Assert.That(actualFirstId, Is.EqualTo("fred"));
        }

        [Test]
        public void TestNoFirstId() 
        {
            IdentifiableObject testObject = new IdentifiableObject(new string[] { "", "bob" });

            string noFirstId = testObject.FirstId;

            Assert.That(noFirstId, Is.EqualTo(String.Empty));
        }

        [Test]
        public void TestAddId() 
        {
            myObject.AddIdentifier("wilma");

            bool addedID = myObject.AreYou("wilma");

            Assert.IsTrue(addedID, "wilma");
        }
    }
}