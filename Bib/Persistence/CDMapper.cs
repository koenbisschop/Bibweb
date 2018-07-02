using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDomain.Business;
using MySql.Data.MySqlClient;

namespace BibDomain.Persistence
{
    class CDMapper
    {
        //veld
        private string _connectionString;


        //methode: Item wegschrijven in tabel
        public void AddCDDetailsToDB(CD cd)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO cd (item_iditem, speelduur) " +
                    " VALUES (@id, @speelduur)", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("speelduur", cd.Speelduur);
            cmd.Parameters.AddWithValue("id",cd.Id);

            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }

        //methode: Items opvragen uit tabel
        public CD GetCDDetailsFromDB(CD cd)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select speelduur from CD where item_iditem=@id", conn);
            cmd.Parameters.AddWithValue("id",cd.Id);
            conn.Open(); //connectie openen
            cd.Speelduur = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close(); //connectie sluiten (!)
            return cd; 
        }

        //constructor
        internal CDMapper()
        {
            _connectionString = Controller.ConnectionString;
        }

    }
}
