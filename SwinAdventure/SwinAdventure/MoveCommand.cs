using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        { }

        public override string Execute(Player p, string[] text)
        {
            Path nextLocation;
                 
            if (text.Length < 2)
            {
                return "Invalid move command format. Please specify a direction.";
            }

            //direction is not specified
           
            if (text.Length == 1)
            {
                return "Where do you want to go?";
            }
            else if (text.Length == 2)
            {
                nextLocation = FindPath(p, text[1]);
            }
            else
            {
                return "I don't know where to go";
            }
            return MoveTo(nextLocation, p);
         
        }

        private Path FindPath(Player player, string pathId)
        {
            GameObject nextLocation = player.Locate(pathId);
            return nextLocation as Path; //cast the Game Object to Path
        }
        private string MoveTo(Path pathId, Player p)
        {
            if (pathId == null)
            {
                return $"Could not find the path {pathId}";
            }
            else
            {
                if (pathId.Destination != null)
                {
                    // Move the player to the destination of the path
                    p.Location = pathId.Destination;
                }
                return $"{pathId.FullDescription}\n{p.Location.FullDescription}";
            }           
        }
    }
}
