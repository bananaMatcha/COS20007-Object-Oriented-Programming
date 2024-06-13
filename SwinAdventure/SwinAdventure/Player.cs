using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
      
        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc) 
        {
            _inventory = new Inventory();
            _location = new Location(Name, desc);
        }

        //method allows an Player to search for other objects either around player or within its inventory.
        public GameObject Locate(string id) 
        {
            // Check if the id matches the player's identifiers
            //(player locates itself)
            if (AreYou(id))
            {
                return this;
            }
           
            // Check if the id matches the player's inventory identifiers
            // (player locates items in its inventory)
            GameObject itemInInventory = _inventory.Fetch(id);
            if (itemInInventory != null)
            {
                return itemInInventory;
            }
            // Check if the id matches the player's current location identifiers
            // (player locates items/ paths in its location)
            GameObject itemInLocation = _location.Locate(id);
            if (itemInLocation != null)
            {
                return itemInLocation;
            }
            // Return null if the object is not found in the player or its inventory
            return null;
        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}.\nYou are carrying:\n{_inventory.ItemList}";
            }
        }
        public Inventory Inventory 
        {
            get { return _inventory; }
        }
        public Location Location 
        {  
            get { return _location; } 
            set { _location = value; }
        }

    }
}
