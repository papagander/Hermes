
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Models;
public interface IValued : IIndexed
{
    public string Value { get; set; }
}
/*
    public interface IJunctionTable<T1, T2> : IIndexed where T1 : IIndexed where T2 : IIndexed
    {
        // A table used to create a link between two other tables.
        public int T1Id { get; set; }
        public int T2Id { get; set; }
        public T1 MyT1 { get; set; }
        public T2 MyT2 { get; set; }
    }
*/

