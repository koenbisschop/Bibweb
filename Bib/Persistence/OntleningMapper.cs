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
    internal class OntleningMapper
    {
        //veld
        private string _connectionString;

        //methode: Gebruiker wegschrijven in tabel
        internal void AddOntleningToDB(int lidId, Ontlening ontlening)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            //insert into, met gebruik van parameters voor 'values'
            MySqlCommand cmd;
            cmd = new MySqlCommand("INSERT INTO ontlening (ontleendatum, terugdatum, exemplaar_idexemplaar, gebruiker_idgebruiker) " +
                    " VALUES (@ontleendatum, @terugdatum, @exemplaarid, @gebruikerid)", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("ontleendatum", ontlening.Vanaf);
            cmd.Parameters.AddWithValue("terugdatum", ontlening.Tot);
            cmd.Parameters.AddWithValue("exemplaarid", ontlening.Exemplaar.Id);
            cmd.Parameters.AddWithValue("gebruikerid", lidId);

            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }

        internal void WijzigOntleningInDB(Ontlening ontlening)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            //insert into, met gebruik van parameters voor 'values'
            MySqlCommand cmd;
            cmd = new MySqlCommand("UPDATE ontlening SET ontleendatum=@vanaf, terugdatum=@tot WHERE exemplaar_idexemplaar=@exemplaarId;",conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("vanaf", ontlening.Vanaf);
            cmd.Parameters.AddWithValue("tot", ontlening.Tot);
            cmd.Parameters.AddWithValue("exemplaarid", ontlening.ExemplaarId);

            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }


        internal void DeleteOntleningFromDB(Ontlening ontlening)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd;
            cmd = new MySqlCommand("DELETE FROM ontlening WHERE exemplaar_idexemplaar=@idexemplaar", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("idexemplaar",ontlening.Exemplaar.Id);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }

        //methode: Gebruikers opvragen uit tabel
        internal List<Ontlening> GetOntleningenFromDB(Lid lid)
        {
            //Ontleningen zijn gebaseerd op gebruikers (leden) en op exemplaren van items. Deze entiteiten moeten dus beschikbaar zijn!
            List<Ontlening> lijst = new List<Ontlening>();
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            MySqlCommand cmd = new MySqlCommand("select * from ontlening where gebruiker_idgebruiker=@lid", conn);
            cmd.Parameters.AddWithValue("lid", lid.Id);
            conn.Open(); //connectie openen
            MySqlDataReader dataReader = cmd.ExecuteReader(); //reader uitvoeren volgens bovenstaand command

            while (dataReader.Read()) //zolang er een record ingelezen kan worden
            {
                
                //opvragen van 
                Ontlening ontlening;
                int idGebruiker = Convert.ToInt32(dataReader["gebruiker_idgebruiker"]);
                //zet idGebruiker om in de entiteit gebruiker
                int idExemplaar = Convert.ToInt32(dataReader["exemplaar_idexemplaar"]);
                ontlening = new Ontlening(
                    idExemplaar,
                    Convert.ToDateTime(dataReader["ontleendatum"]),
                    Convert.ToDateTime(dataReader["terugdatum"])
                );
                lijst.Add(ontlening);
            }

            conn.Close(); //connectie sluiten (!)
            return lijst; //lijst met personen afgeven als resultaat
        }
        //constructor
        internal OntleningMapper()
        {
            _connectionString = Controller.ConnectionString;
        }
    }
}
