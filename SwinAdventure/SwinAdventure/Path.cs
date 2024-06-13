using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private bool _locked; //to make a path lockable
        private Location _destination;

        public Path(string[] id, string name, string desc, Location destination) : base(id, name, desc)
        {
            _destination = destination;
            _locked = false;
        }

        public Location Destination
        {
            get { return _destination; }
        }
        public bool IsLocked
        {
            get { return _locked; }
            set { _locked = value; }
        }
        public override string FullDescription
        {
            get 
            {
                return $"\nYou are moving towards {this.Name}." +
                       $"\nYou travel through {base.FullDescription}." + //contextual desc
                       $"\nYou have arrived at the {Destination.Name}. \n"; //linked to a destination
            }
        }
    }
}
