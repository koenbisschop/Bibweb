using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDomain.Business;
using MySql.Data.MySqlClient;

namespace BibDomain.Persistence
{
    class BoekMapper
    {
        //veld
        private string _connectionString;


        //methode: Item wegschrijven in tabel
        public void AddBoekDetailsToDB(Boek boek)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO boek (item_iditem, ablz) " +
                    " VALUES (@id, @ablz)", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("ablz", boek.ABlz);
            cmd.Parameters.AddWithValue("id",boek.Id);

            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }

        //methode: Items opvragen uit tabel
        public Boek GetBoekDetailsFromDB(Boek boek)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select ablz from boek where item_iditem=@id;", conn);
            cmd.Parameters.AddWithValue("id",boek.Id);
            conn.Open(); //connectie openen
            boek.ABlz = Convert.ToInt32(cmd.ExecuteScalar()); 
            conn.Close(); //connectie sluiten (!)
            return boek; 
        }

        //constructor
        internal BoekMapper()
        {
            _connectionString = Controller.ConnectionString;
        }

    }
}
