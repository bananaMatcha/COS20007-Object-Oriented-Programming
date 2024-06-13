using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor 
    {
        List<Command> _commands;
        public CommandProcessor()
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command c)
        {
            _commands.Add(c);
        }

        public string CallCommand(Player player, string[] text)
        {
            foreach (Command command in _commands)
            {
                //identify if this is a "look" or "move" or invalid command
                if (command.AreYou(text[0].ToLower()))
                {
                    return command.Execute(player, text);
                }
            }
            return null;
        }
    }
}
