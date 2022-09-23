using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Models
{
    public interface ISubTypeOf<SuperClass> : IIndexed where SuperClass : IIndexed
    {
        SuperClass MySuper { get; set; }
        int MySuperId { get; set; }
    }
}
