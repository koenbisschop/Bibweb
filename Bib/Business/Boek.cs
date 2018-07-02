using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Boek:Item
    {
        int _aBlz = 100;
        //properties
        public int ABlz {
            get
            {
                return _aBlz;
            } 
            internal set 
            {
                //if (value <= 0) throw new ArgumentException("Het aantal bladzijden moet groter zijn dan 0");
                _aBlz = value;
            } 
        }
        internal Boek(string titel, int id, int ablz=100): base(titel, id)
        {
            _aBlz = ablz;
        }

    }
}
