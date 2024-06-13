using Clock;
using NUnit.Framework;

namespace TestClock
{
    public class Tests
    {
        Clock.Clock myClock = new Clock.Clock(); // not sure why Clock is identified as namespace,
                                                 // thats why i have to say Clock.Clock = Clock class within the Clock namespace.
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestClockTick()
        {
            myClock.Ticks();
            
            Assert.That(myClock.DisplayTime(),Is.EqualTo("00:00:01"));
        }

        [Test]
        public void TestMinutedisplay()
        {
            Clock.Clock testClock = new Clock.Clock();
            for (int i = 0; i < 120; i++)
            {
                testClock.Ticks();
            }


            Assert.That(testClock.DisplayTime(), Is.EqualTo("00:02:00"));
        }
        [Test]
        public void TestReset() 
        {
            myClock.Reset();
            Assert.That(myClock.DisplayTime(), Is.EqualTo("00:00:00"));
        }
    }
}