using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Ontlening
    {
        private int _exemplaarId;
        //constructoren
        //internal constructor omdat de ontlening de gegevens van lid en exemplaar wijzigt
        public Ontlening(int exemplaarId, DateTime vanaf, DateTime tot)
            : this(exemplaarId, vanaf)
        {
            Tot = tot;
        }
        public Ontlening(int exemplaarId, DateTime vanaf)
        {
            _exemplaarId = exemplaarId;
            //if (this.Exemplaar == null) throw new IndexOutOfRangeException("Dit exemplaar werd niet gevonden");
            Vanaf = vanaf;
            //duid aan dat dit exemplaar niet opnieuw kan uitgeleend worden
            Exemplaar.SetStatus( OntleenStatus.Ontleend);
        }

        //properties
        public DateTime Vanaf { get; internal set; }
        public DateTime Tot { get; internal set; }

        public Boete Boete { get; private set; }

        public string Titel
        {
            get
            {
                return Exemplaar.Item.Titel;
            }
        }
        public Int32 ExemplaarId
        {
            get
            {
                return _exemplaarId;
            }
        }
        public Exemplaar Exemplaar
        {
            get
            {
                return (Exemplaar) ExemplarenRepository.GetInstance().GetEntity(_exemplaarId);
            }
        }

        //methods

        internal Boete Terugbrengen(DateTime tot)
        {
            Tot = tot;
            Exemplaar.SetStatus ( OntleenStatus.Beschikbaar);
            Boete = Boete.BerekenBoete(this);
            return Boete;
        }

    }
}

