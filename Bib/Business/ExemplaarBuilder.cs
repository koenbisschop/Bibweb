using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public static class ExemplaarBuilder
    {
        public static Exemplaar BuildExemplaar(Int32 itemId)
        {
            //controle geldige argumenten
            ItemsRepository _ir =ItemsRepository.GetInstance();
            Item _item = _ir.Entities.Find(i => i.Id == itemId);
            if (_item == null) 
                throw new ArgumentException("Deze titel is onbekend");

            //bepaal Id voor het nieuwe exemplaar
            ExemplarenRepository _er = ExemplarenRepository.GetInstance();
            int _id = _er.GetNextId();

            //nieuw exemplaar aanmaken
            Exemplaar _ex = new Exemplaar(itemId, _id, OntleenStatus.Beschikbaar);

            //nieuwe exemplaar in repository plaatsen (+ persistentie)
            _er.AddEntity(_ex);

            //return
            return _ex;
        }
    }
}
