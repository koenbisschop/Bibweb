using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public enum OntleenStatus
    {
        Beschikbaar = 0,
        Ontleend = 1
    }

    public class Exemplaar : Entity, IComparable, IEquatable<Exemplaar>
    {
        private int _itemId;
        private OntleenStatus _status = OntleenStatus.Beschikbaar;
        internal Exemplaar(int itemId, int id, OntleenStatus status) : base(id)
        {
            _itemId = itemId;
            _status = status;
        }
        public int ItemId
        {
            get
            {
                return _itemId;
            }
        }
        public Item Item
        {
            get
            {
                ItemsRepository ir = ItemsRepository.GetInstance();
                return ir.GetEntity(ItemId);
            }
        }
        public OntleenStatus Status
        {
            get
            {
                return _status;
            }
        }
        internal void SetStatus(OntleenStatus ontleend)
        {
            _status = ontleend;
        }
        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(Exemplaar)) throw new NotImplementedException();
            Exemplaar other = (Exemplaar)obj;
            if ((this.Id == null) || (other.Id == null))
            {
                return this.Item.Titel.CompareTo(other.Item.Titel);
            }
            return ((int)this.Id).CompareTo((int)other.Id);
        }
        public bool Equals(Exemplaar other)
        {
            return other.Id.Equals(Id);
        }
    }
}
