using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand(): base(new string[] { "look" }) //identify the Look command by "look"
        { }
        public override string Execute(Player player, string[] text)
        {
            IHaveInventory _container = null; 
            string _thingId = null;
            //

            if (text.Length == 3 || text.Length == 5) 
            {
                if (text[0].ToLower() == "look")
                {
                    if (text[1].ToLower() == "at")
                    {
                        switch (text.Length)
                        {
                            case 3:
                                _container = player;
                                _thingId = text[2];                       
                                break;
                            case 5:
                                if (text[3].ToLower() != "in")
                                {
                                    return "What do you want to look in?";
                                }

                                _container = FetchContainer(player, text[4]);

                                if (_container == null)
                                { 
                                    return $"I cannot find the {text[4]}"; 
                                }

                                _thingId = text[2];
                                break;
                        }
                    }
                    else
                    {
                        return "What do you want to look at?";
                    }
                }
                else
                {
                    return "Error in look input";
                }
            }
            else
            {
                return "I don't know how to look like that";
            }

            if (_container != null)
            {
                string result = LookAtIn(_thingId, _container);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return $"I cannot find the {_thingId} in {_container.Name}";
                }
            }
            return "Error executing command";
        }

        //check if player can locate the container (e.g location, bag, inventory)
        private IHaveInventory FetchContainer(Player player, string containerid)
        {
               GameObject container = player.Locate(containerid);           
               if (container != null)
               {
                   return container as IHaveInventory; //cast the Game Object to container's type, which is IHaveInventory
               }
               return null; 
        }

        //return the item's Full description if container is not null
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject foundObj = container.Locate(thingId);
            if (foundObj != null)
            { 
                return foundObj.FullDescription; 
            }
            else
            { 
                return null; 
            }
     
        }

    }
}

