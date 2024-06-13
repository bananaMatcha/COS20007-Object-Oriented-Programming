using NUnit.Framework;
using Clock;

namespace TestCounter
{
    public class Tests
    {
        // Arrange
        Counter myCounter = new Counter("myCounter");

        [Test]
        public void TestInitialisation()
        {
            Counter aCounter = new Counter("myCounter");
            // Act & Assert
            Assert.That(aCounter.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void TestIncrement()
        {
          
            // Act
            myCounter.Increment();

            // Assert
            Assert.That(myCounter.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void TestMultipleIncrement()
        {
            Counter testCounter = new Counter("testCounter");
            // Act
            for (int i = 0; i < 10; i++)
            {
                testCounter.Increment();
            }

            // Assert
            Assert.That(testCounter.Ticks, Is.EqualTo(10));
        }
        [Test]
        public void TestReset() 
        {
            myCounter.Reset();
            Assert.That(myCounter.Ticks, Is.EqualTo(0));
        }
    }
}
