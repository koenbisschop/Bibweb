using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public enum DragerType
    {
        Boek=1,
        CD
    }
    public class Item: Entity
    {
        //constanten
        public const decimal DEFAULT_ONTLEEN_TARIEF = 0.3M; //€
        public const decimal DEFAULT_BOETE_TARIEF = 1.0M; //€ per begonnen week te laat
        public const int DEFAULT_ONTLEEN_TERMIJN = 14; //dagen
        //attributen
        private String _titel;
        //constructoren
        internal Item(string titel, int id): base(id)
        {
            _titel = titel;
        }
        //properties
        public String Titel
        {
            get
            {
                return _titel;
            }
            internal set
            {
                _titel = value;
            }
        }
        public virtual decimal OntleenTarief //in € 
        {
            get
            {
                return DEFAULT_ONTLEEN_TARIEF;
            }
        }
        public virtual int OntleenTermijn  //in dagen 
        {
            get
            {
                return DEFAULT_ONTLEEN_TERMIJN;
            }
        }
        public virtual decimal BoeteTarief //in € per week
        {
            get
            {
                return DEFAULT_BOETE_TARIEF;
            }
        }
    }
}
