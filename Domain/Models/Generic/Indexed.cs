﻿using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Generic
{
    public abstract class Indexed : IIndexed
    {
        public int Id { get; set; }
    }
}
