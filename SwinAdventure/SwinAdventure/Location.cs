using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory // location is identifiable and can contain items (as IHaveInventory)
    {
        public Inventory _inventory;
        public List<Path> _paths; //location includes many paths
        
        public Location (string name, string desc) : base(new string[] {"room", "here"}, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        // checking if the object matches the location itself or is in its inventory.
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            //locate if location has the item player is looking for
            GameObject itemInInventory = _inventory.Fetch(id);
            if (itemInInventory != null)
            {
                return itemInInventory;
            }
            //locate the path in the location where player is at
            Path availablePath = this.GetPath(id);
            if (availablePath != null)
            {
                return availablePath;
            }
            return null;
        }

        //check which path this location can lead to
        //return available path


       public Path GetPath(string id)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return null;
        }
  
        //add paths to a location
        public void AddPath(Path path)
        { 
            _paths.Add(path); 
        }

        public override string FullDescription
        {
            get
            {
                return $"You are at {Name}.\nRoom Description: {base.FullDescription}." +
                    $"\n{PathList}\n{ItemList}";
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        //return paths available in this location
        public string PathList
        {
            get
            {
                if (_paths.Count == 0)
                {
                    return "\nThere are no exits.";
                }
                else
                {
                    string list = "Paths that you can go to:\n";
                    foreach (Path path in _paths)
                    {
                        list += path.FirstId + "\n";
                    }
                    return list;
                }
            }
        }
        //return Item list, check if there is any item in the location
        public string ItemList
        {
            get
            {
                if (_inventory != null)
                {
                    return $"In this room, you can see: {_inventory.ItemList}";
                }
                else
                {
                    return $"There is no item in the room";
                }
            }
        }

    }
}
