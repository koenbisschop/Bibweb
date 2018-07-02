using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDomain.Business;
using MySql.Data.MySqlClient;

namespace BibDomain.Persistence
{
    internal class ExemplaarMapper
    {
        //veld
        private string _connectionString;

        //methode: Item wegschrijven in tabel
        internal Exemplaar AddExemplaarToDB(Exemplaar exemplaar)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO exemplaar (idexemplaar, item_id ) " +
                    " VALUES (@exemplaar_id, @item_id)", conn);
            cmd.Parameters.AddWithValue("item_id", exemplaar.ItemId);
            cmd.Parameters.AddWithValue("exemplaar_id", exemplaar.Id);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren

            conn.Close(); //connectie sluiten (!)
            return exemplaar;
        }

        //methode: Items opvragen uit tabel
        internal List<Exemplaar> GetExemplarenFromDB()
        {
            List<Exemplaar> _Exemplaren = new List<Exemplaar>();
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select idexemplaar, item_id, IF(ISNULL(exemplaar_idexemplaar),0,1) AS status " +
                " from exemplaar left join ontlening on idexemplaar = exemplaar_idexemplaar ", conn);
            conn.Open(); //connectie openen
            MySqlDataReader dataReader = cmd.ExecuteReader(); //reader uitvoeren volgens bovenstaand command

            while (dataReader.Read()) //zolang er een record ingelezen kan worden
            {
                _Exemplaren.Add(new Exemplaar(Convert.ToInt32(dataReader["item_id"]), 
                                              Convert.ToInt32(dataReader["idexemplaar"]),
                                              (OntleenStatus) Convert.ToInt16(dataReader["status"])));
            }

            conn.Close(); //connectie sluiten (!)
            return _Exemplaren; 
        }

        //methode: Exemplaar verwijderen uit database
        internal void RemoveExemplaarFromDB(int exemplaarId)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM exemplaar WHERE idexemplaar=@idexemplaar; ", conn);
            cmd.Parameters.AddWithValue("idexemplaar", exemplaarId);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }


        //constructor
        internal ExemplaarMapper()
        {
            _connectionString = Controller.ConnectionString;
        }
    }
}
