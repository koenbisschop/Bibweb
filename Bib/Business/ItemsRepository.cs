using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    class ItemsRepository 
    {
        internal List<Item> Entities {get; private set;}

        private static ItemsRepository _instance;
        //constructor
        private ItemsRepository()
        {
            Entities = Persistence.Controller.GetItemsFromDB();

        }

        internal Int32 GetNextId()
        {
            return Entities.Max(e => e.Id) + 1 ;
        }

        static internal ItemsRepository GetInstance()
        {
            if (_instance == null) _instance = new ItemsRepository();
            return _instance;
        }
        
        internal void AddEntity(Item item)
        {
            Entities.Add(item);
            Persistence.Controller.AddItemToDB(item);
        }

        internal List<Item> GetAll()
        {
            List<Item> _Items = new List<Item>();
            Entities.ForEach(e => _Items.Add((Item) e));
            return _Items;
        }

        internal Item GetEntity(int id)
        {
            Item item = (Item) Entities.Find(e => e.Id == id);
            return item;
        }
    }
}
