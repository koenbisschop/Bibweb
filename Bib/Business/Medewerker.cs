using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Medewerker: Gebruiker
    {
        public Medewerker(int id, string gebruikersnaam, string paswoord, String voornaam, String achternaam, Adres adres=null): base(id,gebruikersnaam,paswoord,Rol.Medewerker, voornaam, achternaam,adres)
        {
        }

        internal decimal Afrekenen(Lid lid, decimal ontvangen)
        {
            decimal _terug = 0.0M;
            if (ontvangen < 0) {
                throw new ArgumentException("U ontvangt enkel geld bij teruggave.");
            }
            else {
                lid.Saldo -= ontvangen;
                if (lid.Saldo < 0)
                {
                    _terug = lid.Saldo;
                    lid.Saldo = 0.0M;
                }
            }
            return _terug;
        }
    }
}
