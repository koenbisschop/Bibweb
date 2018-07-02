using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//reference
using MySql.Data.MySqlClient; //merk op: enkel in mapper SQL!
//geen reference nodig
using BibDomain.Business;

namespace BibDomain.Persistence
{
    class GebruikerMapper
    {
        //veld
        private string _connectionString;


        //methode: Gebruiker wegschrijven in tabel
        internal Gebruiker AddGebruikerToDB(Gebruiker gebruiker, Int32? adresId)
        {
            Rol rol=0;
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            //insert into, met gebruik van parameters voor 'values'
            MySqlCommand cmd;
            cmd = new MySqlCommand("INSERT INTO gebruiker (gebruikersnaam, paswoord," +
                    "vnaam,anaam,rol_idrol,adres_idadres) VALUES (@gebruikersnaam, @paswoord," +
                    "@vnaam,@anaam,@rol_idrol,@adres_idadres)", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("gebruikersnaam", gebruiker.Gebruikersnaam);
            cmd.Parameters.AddWithValue("paswoord", gebruiker.Paswoord);
            cmd.Parameters.AddWithValue("vnaam", gebruiker.Voornaam);
            cmd.Parameters.AddWithValue("anaam", gebruiker.Achternaam);
            cmd.Parameters.AddWithValue("adres_idadres", adresId);
            //bepaal rolid voor de gebruiker
            if (gebruiker.GetType() == typeof(Lid))
            { 
                rol = Rol.Lid;
            }
            else if (gebruiker.GetType() == typeof(Medewerker)) 
            {
                rol = Rol.Medewerker;
            }
            cmd.Parameters.AddWithValue("rol_idrol", (int) rol);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
            return gebruiker;
        }


        //methode: Gebruikers opvragen uit tabel
        internal List<Gebruiker> GetGebruikersFromDB()
        {
            List<Gebruiker> lijst = new List<Gebruiker>();
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            MySqlCommand cmd = new MySqlCommand("select * from gebruiker left join adres on gebruiker.adres_idadres=adres.idadres", conn);

            conn.Open(); //connectie openen
            MySqlDataReader dataReader = cmd.ExecuteReader(); //reader uitvoeren volgens bovenstaand command

            while (dataReader.Read()) //zolang er een record ingelezen kan worden
            {
                Gebruiker gebruiker=null;
                //Het adres wordt niet opgehaald! Dit wordt bepaald door de controller.
                Rol rol = (Rol) Convert.ToInt16(dataReader["rol_idrol"]);
                if (rol == Rol.Lid) 
                {
                    gebruiker = new Lid(
                        Convert.ToInt16(dataReader["idgebruiker"]),
                        dataReader["gebruikersnaam"].ToString(),
                        dataReader["paswoord"].ToString(),
                        Convert.ToDecimal(dataReader["saldo"]),
                        dataReader["vnaam"].ToString(),
                        dataReader["anaam"].ToString(),
                        null);
                }
                else 
                {
                    gebruiker = new Medewerker(
                        Convert.ToInt16(dataReader["idgebruiker"]),
                        dataReader["gebruikersnaam"].ToString(),
                        dataReader["paswoord"].ToString(),
                        dataReader["vnaam"].ToString(),
                        dataReader["anaam"].ToString(),
                        null
                        );
                }
                if (gebruiker != null) lijst.Add(gebruiker);
            }

            conn.Close(); //connectie sluiten (!)
            return lijst; //lijst met personen afgeven als resultaat
        }
        //constructor
        internal GebruikerMapper()
        {
            _connectionString = Controller.ConnectionString;
        }
    }
}
