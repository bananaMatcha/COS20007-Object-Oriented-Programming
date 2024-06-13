using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        public List<string> _identifiers;
        public IdentifiableObject(string[] identifier) 
        {
            _identifiers = new List<string>(identifier);
        }

        public virtual bool AreYou(string identifier)
        {
            string id = identifier.ToLower();
            return _identifiers.Contains(id);
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return string.Empty; //return empty string
                }
            }

        }

        public void AddIdentifier(string identifier)
        {
            _identifiers.Add(identifier.ToLower());
        }

    }
}
