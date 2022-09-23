using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Models
{
    public interface ISuperTypeOf<SubClass> : IIndexed where SubClass : IIndexed
    {
        SubClass? MySub { get;  }
    }
}
