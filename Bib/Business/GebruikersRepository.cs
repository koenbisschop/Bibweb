using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    internal class GebruikersRepository: Repository<Gebruiker>
    {
        private static GebruikersRepository _instance;
        //constructor
        private GebruikersRepository()
        {
            Entities = Persistence.Controller.GetGebruikersFromDB();
            foreach (Gebruiker gebruiker in Entities)
            {
                if (gebruiker.GetType() == typeof(Lid))
                {
                    //haal de ontleningen van dit lid op
                    Lid lid = (Lid) gebruiker;
                    lid.Ontleningen = Persistence.Controller.GetOntleningenFromDB(lid);
                }
            }
        }
        
        internal static GebruikersRepository GetInstance()
        {
            if (_instance == null) _instance = new GebruikersRepository();
            return _instance;
        }

        internal override Gebruiker GetEntity(int id)
        {
            Gebruiker gebruiker = (Gebruiker)Entities.Find(e => e.Id == id);
            return gebruiker;
        }
        internal override void AddEntity(Gebruiker gebruiker)
        {
            gebruiker = Persistence.Controller.AddGebruikerToDB(gebruiker);
            Entities.Add(gebruiker);
        }

        internal override List<Gebruiker> GetAll()
        {
            List<Gebruiker> _gebruikers = new List<Gebruiker>();
            Entities.ForEach(e => _gebruikers.Add((Gebruiker)e));
            return _gebruikers;
        }

        internal override int GetNextId()
        {
            return Entities.Max(e => e.Id) + 1;
        }

    }   
}
