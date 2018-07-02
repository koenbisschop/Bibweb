using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Lid: Gebruiker
    {
        private List<Ontlening> _ontleningen;
        public decimal Saldo { get; internal set; }
        public List<Ontlening> Ontleningen
        {
            get
            {
                return _ontleningen;
            }
            internal set
            {
                _ontleningen = value;
            }
        }
        internal Lid(Int32 id, String gebruikersnaam, string paswoord, String voornaam, String achternaam, Adres adres=null): this(id, gebruikersnaam, paswoord, 0.0M, voornaam, achternaam, adres)
        {
        }
        internal Lid(int id, String gebruikersnaam, string paswoord, Decimal saldo, String voornaam, String achternaam, Adres adres = null)
            : base(id, gebruikersnaam, paswoord, Rol.Lid, voornaam, achternaam, adres)
        {
            Ontleningen = new List<Ontlening>();
            Saldo = saldo;
        }
        //methods
        internal Ontlening NieuweOntlening(int exemplaarId, DateTime vanaf)
        {
            Ontlening ontlening = new Ontlening(exemplaarId, vanaf);
            Ontleningen.Add(ontlening);
            //saldo lid aanpassen
            decimal ontleenBedrag = ontlening.Exemplaar.Item.OntleenTarief;
            Saldo += ontleenBedrag;

            return ontlening;
        }
        /// <summary>
        /// Terugbrengen van een ontleend exemplaar door een lid
        /// </summary>
        /// <param name="exemplaar"></param>
        /// <param name="tot"></param>
        /// <returns>De boete die eventueel moet betaald worden (null indien geen boete).</returns>
        internal Ontlening Terugbrengen(Int32 exemplaarId, DateTime tot)
        {
            Ontlening ontlening = Ontleningen.Find(o => o.Exemplaar.Id == exemplaarId);
            if (ontlening == null) throw new InvalidOperationException("Dit exemplaar is niet ontleend door dit lid");

            Boete boete = ontlening.Terugbrengen(tot);
            if (boete != null)
            {
                Saldo += boete.Bedrag;
            }

            Ontleningen.Remove(ontlening);

            return ontlening;

        }
        
        internal Ontlening WijzigOntlening(Int32 exemplaarId, DateTime vanaf, DateTime? tot)
        {
            Ontlening ontlening = _ontleningen.Find(o => o.Exemplaar.Id == exemplaarId);
            ontlening.Vanaf = vanaf;
            if (tot != null) ontlening.Tot = (DateTime) tot;
            return ontlening;
        }
        

    }
}
