﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Business
{
    public class Entity
    {
        public int Id { get; private set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
