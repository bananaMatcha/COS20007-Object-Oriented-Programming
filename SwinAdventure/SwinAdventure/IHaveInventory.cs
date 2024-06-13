using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public interface IHaveInventory //this class is used to treat Player and Location as the object that contains Inventory
    {
        public GameObject Locate(string id);
        public string Name
        {
            get { return Name; }
        }
    }
}
