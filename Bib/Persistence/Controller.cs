using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDomain.Business;
using System.Configuration;

namespace BibDomain.Persistence
{
    internal static class Controller
    {
        internal static String ConnectionString{get; private set;}

        /*
        private static Controller _controller;

        //constructor
        private Controller(string connectionString)
        {
            _connectionString = connectionString;
        }

        //singleton aanmaken
        internal static Controller GetInstance(string connectionString)
        {
            if (_controller == null) _controller = new Controller(connectionString);
            return _controller;
        }

        internal static Controller GetInstance()
        {
            if (_controller == null) throw new ArgumentException();
            return _controller;
        }
        */

        //gebruikermethoden
        static internal List<Gebruiker> GetGebruikersFromDB()
        {
            List<Gebruiker> _gebruikersLijst;
            GebruikerMapper _gebruikermapper = new GebruikerMapper();
            AdresMapper _adresMapper = new AdresMapper();
            _gebruikersLijst = _gebruikermapper.GetGebruikersFromDB();
            foreach (Gebruiker gebruiker in _gebruikersLijst)
            {
                _adresMapper.GetAdressFromDB((Int32)gebruiker.Id);
            }
            return _gebruikersLijst;
        }
        static internal Gebruiker AddGebruikerToDB(Gebruiker gebruiker)
        {
            GebruikerMapper _gebruikermapper = new GebruikerMapper();
            Int32? _adresId = null;
            if (gebruiker.Adres != null)
            {
                AdresMapper _adresMapper = new AdresMapper();
                _adresId = _adresMapper.AddAdresToDB(gebruiker.Adres);
            }
            return _gebruikermapper.AddGebruikerToDB(gebruiker, _adresId);
        }

        //item methoden
        static internal List<Item> GetItemsFromDB()
        {
            List<Item> _itemLijst;
            ItemMapper _itemmapper = new ItemMapper();
            BoekMapper _boekmapper = new BoekMapper();
            CDMapper _cdmapper  = new CDMapper();
            _itemLijst = _itemmapper.GetItemsFromDB();
            foreach (Item item in _itemLijst)
            {
                if (item.GetType() == typeof(Boek))
                    _boekmapper.GetBoekDetailsFromDB((Boek)item);
                else if (item.GetType() == typeof(CD))
                    _cdmapper.GetCDDetailsFromDB((CD)item);
            }
            return _itemLijst;
        }

        static internal Item AddItemToDB(Item item)
        {
            ItemMapper _itemMapper = new ItemMapper();
            item = _itemMapper.AddItemToDB(item);
            if (item.GetType() == typeof(Boek))
            {
                BoekMapper bm = new BoekMapper();
                bm.AddBoekDetailsToDB((Boek)item);
            }
            else
            {
                CDMapper cm = new CDMapper();
                cm.AddCDDetailsToDB((CD)item);
            }
            return item;
        }

        static internal void UpdateItemInDB(Item item)
        {
            ItemMapper _itemMapper = new ItemMapper();
            _itemMapper.UpdateItemInDB(item);
        }

        //exemplaar methoden
        static internal List<Exemplaar> GetExemplarenFromDB()
        {
            List<Exemplaar> _exemplarenLijst;
            _exemplarenLijst = new List<Exemplaar>();
            ExemplaarMapper _exemplaarMapper = new ExemplaarMapper();
            _exemplarenLijst = _exemplaarMapper.GetExemplarenFromDB();
            return _exemplarenLijst;
        }

        static internal Exemplaar AddExemplaarToDB(Exemplaar exemplaar)
        {
            ExemplaarMapper _exemplaarMapper = new ExemplaarMapper();
            return _exemplaarMapper.AddExemplaarToDB(exemplaar);
        }

        static internal void RemoveExemplaarFromDB(Exemplaar exemplaar)
        {
            ExemplaarMapper _exemplaarMapper = new ExemplaarMapper();
            _exemplaarMapper.RemoveExemplaarFromDB((int) exemplaar.Id);
        }

        //ontlening methoden
        static internal List<Ontlening> GetOntleningenFromDB(Lid lid)
        {
            OntleningMapper _om = new OntleningMapper();
            List<Ontlening> ontleningen = _om.GetOntleningenFromDB(lid);
            return ontleningen;
        }

        static internal void AddOntleningToDB(Int32 lidId, Ontlening ontlening)
        {
            OntleningMapper _om = new OntleningMapper();
            _om.AddOntleningToDB(lidId,ontlening);
        }

        static internal void WijzigOntleningInDB(Ontlening ontlening)
        {
            OntleningMapper _om = new OntleningMapper();
            _om.WijzigOntleningInDB(ontlening);
        }

        static internal void DeleteOntleningFromDB(Ontlening ontlening)
        {
            OntleningMapper _om = new OntleningMapper();
            _om.DeleteOntleningFromDB(ontlening);
        }

        static internal void UpdateSaldoLidInDB(Lid lid)
        {
            LidMapper _lm = new LidMapper();
            _lm.UpdateSaldoLidInDB(lid);
        }
        //constructor
        static internal void ConnectToDB()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["lokalebib"].ToString(); 
            //ConnectionString = "server=localhost;user id=root;password=usbw;port=3307;database=bib";
        }
    }

}
