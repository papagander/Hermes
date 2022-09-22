
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Model;

public interface IIndexed
{
    // Table with an index.
    public int Id { get; set; }

}
public interface INamed : IIndexed
{
    // A table with an index and a name.
    public string Name { get; set; }

}
public interface IReferenceTable<T> : IIndexed where T : IIndexed
{
    public int TId { get; set; }
    public T MyT { get; set; }
}
public interface IReferencedTable<T> : IIndexed where T : IIndexed
{
    public List<T>? MyTs { get; set; }
}
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

