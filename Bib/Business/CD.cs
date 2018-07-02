using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class CD:Item
    {
        int _speelduur = 60;
        //properties
        public int Speelduur {
            get
            {
                return _speelduur;
            } 
            internal set 
            {
                //if (value <= 0) throw new ArgumentException("De speeltijd moet groter zijn dan 0");
                _speelduur = value;
            } 
        }
        internal CD(string titel, int id, int speelduur=60): base(titel, id)
        {
            _speelduur = speelduur;
        }

    }
}
