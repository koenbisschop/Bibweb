using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Adres
    {
        public String Straat { get; private set; }
        public String Straatnummer { get; private set; }
        public String Bus { get; private set; }
        public String Postcode { get; private set; }
        public String Gemeente { get; private set; }
        public Adres(   String straat, String straatnummer, 
                        String postcode, String gemeente, String bus="")
        {
            Straat = straat;
            Straatnummer = straatnummer;
            Bus = bus;
            Postcode = postcode;
            Gemeente = gemeente;
        }
    }
}
