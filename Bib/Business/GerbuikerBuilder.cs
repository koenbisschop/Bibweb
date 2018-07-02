using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public static class GebruikerBuilder
    {
        public static Gebruiker BuildGebruiker(string gebruikersnaam, string paswoord, string voornaam, string achternaam, Rol rol)
        {
            //controle geldige argumenten bij aanmaak van de gebruiker
            GebruikersRepository _gr =GebruikersRepository.GetInstance();
            
            //houd een teller bij en bepaal _g.Id in deze builder
            Int32 _id = _gr.GetNextId();

            //nieuwe gebruiker aanmaken
            Gebruiker _gebruiker = null;
            switch (rol)
            {
                case Rol.Lid:
                    _gebruiker = new Lid(_id,gebruikersnaam, paswoord, voornaam, achternaam);
                    break;
                case Rol.Medewerker:
                    _gebruiker = new Medewerker(_id, gebruikersnaam, paswoord, voornaam, achternaam);
                    break;
            }

            //gebruiker persistent maken in database
            if (Persistence.Controller.ConnectionString != "")
                Persistence.Controller.AddGebruikerToDB(_gebruiker);

            //nieuwe exemplaar in repository plaatsen
            _gr.AddEntity(_gebruiker);

            //return
            return _gebruiker;
        }
    }
}
