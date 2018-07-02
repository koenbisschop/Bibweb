using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BibDomain.Business;

namespace BibDomain.Persistence
{
    internal class LidMapper
    {
        private string ConnectionString { get; set; }
        //methode: gebruikergegevens aanpassen (wel saldo, zonder adres... , rol en zonder ontleningen)
        internal void UpdateSaldoLidInDB(Lid lid)
        {
            //nieuwe connectie met DB met opgegeven connection string
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            //nieuw MySQL-statement voor connectie 'conn' in kwestie (cf. connection string)
            MySqlCommand cmd;
            cmd = new MySqlCommand("UPDATE gebruiker SET saldo = @saldo where idgebruiker = @idgebruiker", conn);
            //invullen van beide parameters voor command 'cmd'
            cmd.Parameters.AddWithValue("idgebruiker", lid.Id);
            cmd.Parameters.AddWithValue("saldo", lid.Saldo);
            conn.Open(); //connectie openen
            cmd.ExecuteNonQuery(); //toevoegen uitvoeren
            conn.Close(); //connectie sluiten (!)
        }
        //constructor
        internal LidMapper()
        {
            ConnectionString = Controller.ConnectionString;
        }
    }
}
