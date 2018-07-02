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
    internal class ItemMapper
    {
        //veld
        private string _connectionString;

        //methode: Item wegschrijven in tabel
        internal Item AddItemToDB(Item item)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            //insert into, met gebruik van parameters voor 'values'
            MySqlCommand cmd = new MySqlCommand("INSERT INTO item (iditem, titel, drager) " +
                    " VALUES (@iditem, @titel, @drager)", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("titel", item.Titel);
            cmd.Parameters.AddWithValue("iditem", item.Id);
            //bepaal drager voor het Item
            DragerType drager=0;
            if (item is Boek)
            {
                drager = DragerType.Boek;
            }
            else if (item is CD)
            {
                drager = DragerType.CD;
            }

            cmd.Parameters.AddWithValue("drager", (int) drager);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren

            conn.Close(); //connectie sluiten (!)

            return item;
        }

        //methode: Items opvragen uit tabel
        internal List<Item> GetItemsFromDB()
        {
            List<Item> lijst = new List<Item>();
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            MySqlCommand cmd = new MySqlCommand("select * from Item", conn);

            conn.Open(); //connectie openen
            MySqlDataReader dataReader = cmd.ExecuteReader(); //reader uitvoeren volgens bovenstaand command

            while (dataReader.Read()) //zolang er een record ingelezen kan worden
            {
                //De specifieke data wordt opgehaald via de controller.
                DragerType drager = (DragerType)Convert.ToInt16(dataReader["drager"]);
                if (drager == DragerType.Boek) 
                {
                    Boek boek = new Boek(dataReader["titel"].ToString(),
                        Convert.ToInt16(dataReader["iditem"]));
                    lijst.Add(boek);
                }
                else if (drager == DragerType.CD)
                {
                    CD cd = new CD(dataReader["titel"].ToString(),
                                Convert.ToInt16(dataReader["iditem"]));
                    lijst.Add(cd);
                }

            }

            conn.Close(); //connectie sluiten (!)
            return lijst; 
        }

        //methode: Item wijzigen in database
        internal void UpdateItemInDB(Item item)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            //insert into, met gebruik van parameters voor 'values'
            MySqlCommand cmd = new MySqlCommand("UPDATE item SET titel = @titel WHERE iditem=@iditem", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("titel", item.Titel);
            cmd.Parameters.AddWithValue("iditem", item.Id);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }

        //constructor
        internal ItemMapper()
        {
            if (Controller.ConnectionString == "") throw new InvalidOperationException("Geen connectie mogelijk");
            _connectionString = Controller.ConnectionString;

        }
    }
}
