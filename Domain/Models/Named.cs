using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class Named : Indexed, INamed
    {
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
