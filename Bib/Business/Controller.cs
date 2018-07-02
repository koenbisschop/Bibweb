using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDomain.Persistence;

namespace BibDomain.Business
{
    public class Controller
    {
        //Responsability: coördineren van de samenwerking tussen business-laag en overige lagen
        //In deze applicatie zorgen de repositories meestal zelf voor het onderhoud van de persistence-laag
        private GebruikersRepository _gebruikersRepository;
        private ItemsRepository _itemsRepository;
        private ExemplarenRepository _exemplarenRepository;

        //property
        public Gebruiker CurrentUser { get; internal set; }

        //constructor
        public Controller()
        {
            //initialiseer de connectie van de persistence laag
            Persistence.Controller.ConnectToDB();
            //laad alle basisgegevens in de repositories
            _itemsRepository = ItemsRepository.GetInstance();
            //_itemsRepository.Entities = Persistence.Controller.GetItemsFromDB();
            _exemplarenRepository = ExemplarenRepository.GetInstance();
            //_exemplarenRepository.Entities = Persistence.Controller.GetExemplarenFromDB();
            _gebruikersRepository = GebruikersRepository.GetInstance();
            //_gebruikersRepository.Gebruikers = Persistence.Controller.GetGebruikersFromDB();
        }

        //gebruiker-methoden
        public Boolean Aanmelden(string naam, string paswoord)
        {
            //zoek de juiste gebruiker
            Gebruiker _aanmelder = _gebruikersRepository.Entities.Find(g => g.Gebruikersnaam.Equals(naam));
            if (_aanmelder != null)
            {
                //check zijn paswoord
                Boolean _aangemeld = _aanmelder.Aanmelden(paswoord);
                if (_aangemeld)
                {
                    CurrentUser = _aanmelder;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public void Afmelden()
        {
            CurrentUser = null;
        }

        public List<Gebruiker> GetLeden()
        {
            return _gebruikersRepository.Entities.FindAll(g => g.GetType() == typeof(Lid));
        }

        public List<Gebruiker> GetGebruikers()
        {
            return _gebruikersRepository.Entities;
        }

        //bibliotheek-items methoden
        public Item ZoekItem(string titel)
        {
            Item item = _itemsRepository.Entities.Find(b => b.Titel == titel);
            /*ofwel: foreach (Item t in _itemsRepository.Items)
            {
                if (t.Titel == titel)
                    return t;
            }*/
            return item;
        }

        public List<Item> GetItems()
        {
            return _itemsRepository.Entities;
        }

        public void WijzigItem(string titel, int id, decimal ontleenTarief=0.0m, int ontleenTermijn=0, decimal boeteTarief=0.0m)
        {
            Item item = _itemsRepository.Entities.Find(b => b.Id == id);
            item.Titel = titel;
            if (item == null) throw new ArgumentException("Deze titel is onbekend");
            //opslaan nieuwe titel
            Persistence.Controller.UpdateItemInDB(item);
        }

        //exemplaren van items
        public List<Exemplaar> GetExemplarenForItem(int itemId)
        {
            return _exemplarenRepository.GetExemplarenVanItem(itemId);
        }

        //ontleen-methodes
        public Ontlening Ontlenen(Int32 lidId, int exemplaarId, DateTime vanaf)
        {
            Lid lid = (Lid)_gebruikersRepository.GetEntity(lidId);
            Ontlening ontlening = lid.NieuweOntlening(exemplaarId, vanaf);
            //alle wijzigingen opslaan in de database
            Persistence.Controller.AddOntleningToDB(lidId,ontlening);
            Persistence.Controller.UpdateSaldoLidInDB(lid);
            return ontlening;
        }

        //exemplaar-methodes
        public void VerwijderExemplaar(int Id)
        {
            Exemplaar exemplaar = _exemplarenRepository.GetEntity(Id);
            if (exemplaar == null) throw new IndexOutOfRangeException("Dit exemplaar werd niet gevonden");
            _exemplarenRepository.RemoveEntity(exemplaar);
        }

        //ontleningen beheren
        public decimal Terugbrengen(Lid lid, Int32 exemplaarId, DateTime tot)
        {
            decimal _boetebedrag = 0.0M;
            //business opstarten

            Ontlening ontlening = lid.Terugbrengen(exemplaarId,tot); //saldo lid wordt indien nodig aangepast!
            Boete boete = ontlening.Boete;
            if (boete != null)
                _boetebedrag = boete.Bedrag;
            else
                _boetebedrag = 0;

            //gewijzigde objecten ook doorspelen aan db!!!
            if (boete != null) 
                Persistence.Controller.UpdateSaldoLidInDB(lid);
            Persistence.Controller.DeleteOntleningFromDB(ontlening);

            return _boetebedrag;
        }
        public List<Ontlening> GetOntleningen(Int32 LidId)
        {
            foreach (Gebruiker g in _gebruikersRepository.Entities)
            {
                if (g is Lid)
                {
                    Lid l = (Lid)g;
                    if (l.Id == LidId)
                        return l.Ontleningen;
                }
            }
            return new List<Ontlening>();
        }

        public void WijzigOntlening(Int32 exemplaarId, DateTime vanaf, DateTime? tot=null, Lid lid = null, string titel="")
        {
            if (lid == null) lid = CurrentUser as Lid;
            if (lid != null)
            {
                Ontlening ontlening = lid.WijzigOntlening(exemplaarId, vanaf, tot);
                Persistence.Controller.WijzigOntleningInDB(ontlening);
            }
        }
        public decimal Afrekenen(Int32 lidId, decimal ontvangen)
        {
            decimal terug;
            //if (CurrentUser.GetType() == typeof(Medewerker))
            if (CurrentUser is Medewerker)
            {
                Medewerker mw = CurrentUser as Medewerker; // = casting zonder exception, null indien CurrentUser geen Medewerker is
                Lid lid = (Lid) _gebruikersRepository.Entities.Find(g => g.Id == lidId);
                terug = mw.Afrekenen(lid, ontvangen);

                //lid is gewijzigd, dus: ook in repository (entiteit)! Dus: aangepaste gegevens naar persistence sturen!
                Persistence.Controller.UpdateSaldoLidInDB(lid);
            }
            else
                throw new InvalidOperationException("Afrekenen gebeurt door de medewerkers");
            return terug;
        }
    }
}
