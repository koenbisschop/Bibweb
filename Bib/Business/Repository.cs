using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    internal abstract class Repository<T> : Repository
    {
        internal List<T> Entities { get; set; }
        internal abstract List<T> GetAll();
        internal abstract T GetEntity(Int32 id);
        internal abstract void AddEntity(T type);
        internal abstract Int32 GetNextId();
    }

    internal abstract class Repository
    {
    }

}
