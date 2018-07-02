using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public static class ItemBuilder
    {
        public static Item BuildItem(String titel, DragerType type)
        {
            ItemsRepository _ir = ItemsRepository.GetInstance();
            int _id = _ir.GetNextId();

            Item item = null;
            switch (type)
            {
                case DragerType.Boek:
                    item = new Boek(titel,_id);
                    break;
                case DragerType.CD:
                    item = new CD(titel, _id);
                    break;
            }
            if (item != null)
            {
                _ir.AddEntity(item);
            }
            else
                throw new ArgumentException();
            return item; //heeft nu ook een Id!
        }
    }
}
