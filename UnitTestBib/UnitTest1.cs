using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibDomain.Business;
using System.Configuration;
using System.Collections.Generic;

namespace UnitTestBib
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FetchUserTest()
        {
            Controller c = new Controller();
            List<Gebruiker> leden = c.GetLeden();
            Assert.AreEqual(leden[0].Gebruikersnaam, "jvercammen");
            //Assert.AreEqual(leden[1].GetType(), typeof(Medewerker));
        }

        [TestMethod]
        public void SaveUserTest()
        {
            Controller c = new Controller();
            Lid lid = new Lid("x", "xxx123", "x", "x",new Adres("e","12","2000","apen","2"));
            c.nieuweGebruiker(lid);
            Assert.IsNotNull(lid.Id);
        }

        [TestMethod]
        public void SaveItemTest()
        {
            Controller c = new Controller();
            Item item = c.nieuwItem("C# for dummies", DragerType.Boek);
            
            Assert.AreEqual(c.ZoekItem("C# for dummies").Titel, "C# for dummies");
            //Assert.IsNotNull(lid);
        }
        
        [TestMethod]
        public void FetchItemTest()
        {
            Controller c = new Controller();
            Item item = c.ZoekItem("Woeste Hoogten");
            Boek boek = item as Boek;
            Assert.IsNotNull(item);
            Assert.AreEqual(boek.ABlz, 175);
        }

        [TestMethod]
        public void FetchExemplaarTest()
        {
            Controller c = new Controller();
            Item item = c.ZoekItem("Woeste Hoogten"); //item 1
            Boek boek = item as Boek;
            Exemplaar exc = c.GetExemplarenForItem(item)[0]; //exemplaar 1
            Assert.AreEqual(exc.Status, OntleenStatus.Ontleend);
        }

        [TestMethod]
        public void OntleenStatusTest()
        {
            Controller c = new Controller();
            Item item = c.ZoekItem("Woeste Hoogten");
            Boek boek = item as Boek;
            Exemplaar exc = c.GetExemplarenForItem(item)[1];

        }
        [TestMethod]
        public void OntlenenTest()
        {
            Controller c = new Controller();
            Item item = c.ZoekItem("Woeste Hoogten");
            Boek boek = item as Boek;
            Exemplaar exc = c.GetExemplarenForItem(item)[1];
            Lid lid = c.GetLeden()[2] as Lid;
            c.Ontlenen(lid, exc, new DateTime(2016, 9, 1));
            Assert.AreEqual(lid.Ontleningen.Count>=1, true);
        }

        [TestMethod]
        public void TerugbrengenTest()
        {
            Controller c = new Controller();
            Item item = c.ZoekItem("Woeste Hoogten");
            Boek boek = item as Boek;
            Exemplaar exc = c.GetExemplarenForItem(item)[1];
            Lid lid = c.GetLeden()[2] as Lid;
            c.Ontlenen(lid, exc, new DateTime(2016, 9, 1));
            decimal bedrag = c.Terugbrengen(lid, exc, new DateTime(2016, 10, 1));
            Assert.AreEqual(bedrag, 3.00M);
        }

        [TestMethod]
        public void ItemTest()
        {
            Controller c = new Controller();
            Item b = c.nieuwItem("Woeste Hoogten 2", DragerType.Boek);
            Assert.IsNotNull(b.Id);
        }

        [TestMethod]
        public void AfrekenenTest()
        {
            Controller c = new Controller();
            Item item = c.ZoekItem("Woeste Hoogten");
            Boek boek = item as Boek;
            Exemplaar exc = c.GetExemplarenForItem(item)[1];
            Lid lid = c.GetLeden()[2] as Lid;
            c.Ontlenen(lid, exc, new DateTime(2016, 9, 1));
            decimal bedrag = c.Terugbrengen(lid, exc, new DateTime(2016, 10, 1));
            Assert.AreEqual(lid.Saldo, 3.00M);
            c.Aanmelden("mvervoort","m123");
            c.Afrekenen(lid, 3.00M);
            Assert.AreEqual(lid.Saldo, 0.0M);
            c.Afmelden();
        }

        [TestMethod]
        public void AanmeldenTest()
        {
            Controller c = new Controller();
            Medewerker mw = new Medewerker("Jan", "J123", "Jan","Janssen");
            c.nieuweGebruiker(mw);
            c.Aanmelden("Jan", "J123");
            Assert.IsNotNull(c.CurrentUser);
        }

    }
}
