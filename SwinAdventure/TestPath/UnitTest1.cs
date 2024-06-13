using SwinAdventure;
using System.Numerics;
namespace TestPath
{
    public class Tests
    {
        Player player;
        Location location1;
        Location location2;
        SwinAdventure.Path path1;
        MoveCommand moveCommand;

        [SetUp]

        public void Setup()
        {
            // Create a Player instance for testing
            player = new Player("Fred", "the mighty programmer");

            // Create locations for testing
            location1 = new Location("Old library", "a library in the mansion");
            location2 = new Location("Garden", "a big garden at the backyard");

            // Creating a path for testing
            path1 = new SwinAdventure.Path(new string[] { "north" }, "Garden Path", "a path leading to the garden", location2);

            // Set up player's initial location
            player.Location = location1;

            // Add path to location
            location1.AddPath(path1);
            moveCommand = new MoveCommand();
        }

        [Test]
        public void PathMovePlayerToItsDestination()
        {
            // Ensure that the player's location changes to the path's destination
            string[] commandInput = { "move", "north"};

            string result = moveCommand.Execute(player, commandInput);
            Assert.That($"\nYou are moving towards Garden Path.\nYou travel through a path leading to the garden.\nYou have arrived at the Garden." +
                        $" \n\nYou are at Garden.\nRoom Description: a big garden at the backyard.\n\nThere are no exits.\nIn this room, you can see: ", Is.EqualTo(result));
        }

        [Test]
        public void CanGetPathFromLocation()
        {
            // Ensure that the path can be retrieved from the location using its identifier
            SwinAdventure.Path expected = path1;
            SwinAdventure.Path actual = location1.GetPath("north");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void CantGetPathWithWrongID()
        {
            // Attempt to get a path with an invalid identifier
            SwinAdventure.Path actual = location1.GetPath("south");

            //can't return the path
            Assert.IsNull(actual);
        }

        [Test]
        public void PlayerRemainsInSameLocationWithInvalidPathIdentifier()
        {
            // player remains in the same location with an invalid path identifier
            string[] commandInput = { "move", "south" };

            string result = moveCommand.Execute(player, commandInput);
            Assert.That("Could not find the path ", Is.EqualTo(result));
        }


    }
}