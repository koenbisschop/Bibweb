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
    class AdresMapper
    {
        //veld
        private string _connectionString;

        //methode: Adres wegschrijven in tabel
        internal Int32 AddAdresToDB(Adres adres)
        {
            //indien 2 personen op hetzelfde adres wonen wordt dit adres nogmaals ingevoerd.
            //gebruik b.v. een stored procedure om dit te vermijden.
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Adres (straat, straatnr," +
                    "bus,postcode, gemeente) VALUES (@straat, @straatnr," +
                    "@bus,@postcode,@gemeente)", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("straat", adres.Straat);
            cmd.Parameters.AddWithValue("straatnr", adres.Straatnummer);
            cmd.Parameters.AddWithValue("bus", adres.Bus);
            cmd.Parameters.AddWithValue("postcode", adres.Postcode);
            cmd.Parameters.AddWithValue("gemeente", adres.Gemeente);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            int adresID = (Int32) cmd.LastInsertedId;
            conn.Close(); //connectie sluiten (!)
            return adresID;
        }

        //methode: Adress opvragen uit tabel
        public Adres GetAdressFromDB(Int32 gebruikerId)
        {
            Adres adres = null;
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            MySqlCommand cmd = new MySqlCommand("select * from Adres where idadres=" +
                                                "(select adres_idadres from gebruiker where idgebruiker=@idgebruiker)", conn);
            cmd.Parameters.AddWithValue("idgebruiker", gebruikerId);
            conn.Open(); //connectie openen
            
            MySqlDataReader dataReader = cmd.ExecuteReader(); //reader uitvoeren volgens bovenstaand command

            while (dataReader.Read()) //zolang er een record ingelezen kan worden
            {
                adres = new Adres(dataReader["straat"].ToString(),
                                dataReader["straatnr"].ToString(),
                                dataReader["bus"].ToString(),
                                dataReader["postcode"].ToString(),
                                dataReader["gemeente"].ToString());
            }
            conn.Close(); //connectie sluiten (!)
            return adres;
        }

        //constructor
        internal AdresMapper()
        {
            _connectionString = Controller.ConnectionString;
        }
    }
}
