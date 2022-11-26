using Domain.Interfaces.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Generic
{
    public abstract class Named : Indexed, INamed
    {
        [NotNull]
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
