using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    class ExemplarenRepository : Repository<Exemplaar>
    {
        private static ExemplarenRepository _instance;
        //constructor
        private ExemplarenRepository()
        {
            Entities = Persistence.Controller.GetExemplarenFromDB();
        }
        static internal ExemplarenRepository GetInstance()
        {
            if (_instance == null) _instance = new ExemplarenRepository();
            return _instance;
        }
        internal override int GetNextId()
        {
            return Entities.Max(e => e.Id) + 1;
        }
        internal override Exemplaar GetEntity(Int32 exemplaarId)
        {
            return (Exemplaar) Entities.Find(e => e.Id == exemplaarId);
        }
        public List<Exemplaar> GetExemplarenVanItem(int itemId)
        {
            if (itemId > 0)
                return Entities.FindAll(entity => entity.Item.Id == itemId);
            else
                return null;
        }
        internal override void AddEntity(Exemplaar exemplaar)
        {
            Entities.Add(exemplaar);
            Persistence.Controller.AddExemplaarToDB(exemplaar);
        }
        internal void RemoveEntity(Exemplaar exemplaar)
        {
            Entities.Remove(exemplaar); //vereist IEquatable interface!
            Persistence.Controller.RemoveExemplaarFromDB(exemplaar);
        }
        internal override List<Exemplaar> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
