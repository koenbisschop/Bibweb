using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BibDomain.Business
{
    public abstract class Gebruiker: Entity
    {
        public string Voornaam { get; internal set; }
        public string Achternaam { get; internal set; }
        public Adres Adres { get; internal set; }
        public Rol Rol { get; internal set; }
        public bool IsAangemeld { get; private set; }
        public string Gebruikersnaam { get; internal set; }
        internal string Paswoord { get; set; }
        public Gebruiker(int id, string gebruikersnaam, string paswoord, Rol rol= Rol.Anoniem, String voornaam = "", String achternaam = "", Adres adres = null): base(id)
        {
            if (IsValidUsername(gebruikersnaam) && IsValidPaswoord(paswoord))
            {
                Gebruikersnaam = gebruikersnaam;
                Paswoord = paswoord;
                IsAangemeld = false;
                Voornaam = voornaam;
                Achternaam = achternaam;
                Adres = adres;
                Rol = rol;
            }
            else
            {
                throw new GebruikerException("Ongeldige gegevens");
            }
        }

        private Boolean IsValidUsername(string username)
        {
            Regex _schrijfwijze = new Regex("^[a-z,A-Z][a-z,A-Z,0-9]*$");
            return _schrijfwijze.IsMatch(username);
        }
        private Boolean IsValidPaswoord(string paswoord)
        {
            return paswoord.Trim().Length >= 4;
        }
        public Boolean Aanmelden(string paswoord)
        {
            IsAangemeld = Paswoord.Equals(paswoord);
            return IsAangemeld;
        }
    }

    public class GebruikerException : Exception
    {
        public GebruikerException(string Message): base(Message)
        {

        }
        public GebruikerException() : base() { }
    }

    public enum Rol
    {
        Anoniem=0,
        Lid=1,
        Medewerker=2
    }
}
