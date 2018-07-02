using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Boete
    {
        //attributen
        private decimal _bedrag=0;
        public decimal Bedrag
        {
            get
            {
                return _bedrag;
            }
        }
        //constructoren
        private Boete(decimal bedrag)
        {
            _bedrag = bedrag;
        }
        //method
        public static Boete BerekenBoete(Ontlening ontlening)
        {
            Boete boete = null;
            decimal bedrag = 0.0M;
            Item t = ontlening.Exemplaar.Item;
            int aantalDagenOK = t.OntleenTermijn;
            TimeSpan ontleenPeriode = ontlening.Tot - ontlening.Vanaf;
            int aantalDagenOntleend = ontleenPeriode.Days;
            int aantalBegonnenWekenTeLaat = (int) Math.Ceiling((aantalDagenOntleend - aantalDagenOK) / 7.0);
            if (aantalDagenOntleend > aantalDagenOK) 
            {
                decimal basisBedragPerWeek = t.BoeteTarief;
                bedrag = aantalBegonnenWekenTeLaat * t.BoeteTarief;
                boete = new Boete(bedrag);
            }
            return boete;
        }
    }
}
