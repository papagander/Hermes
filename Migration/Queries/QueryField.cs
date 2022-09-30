using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using Domain.Interfaces.Models;
using Domain.Models.DataSets;

namespace Domain.Models.Queries;
public class QueryField : Indexed, IReferences<Query>, IReferences<Field>
{
    public override string ToString() => $"{Query.Name}.{Field.Name}";
    // Create a link between a report and a field to be included on said report.
    public int QueryId { get; set; }
    public int FieldId { get; set; }
    public Query Query { get; set; }
    public Field Field { get; set; }
    /*
    public QueryField(Query query, Field field)
    {
        Query = query;
        Field = field;
    }
    */
    int IReferences<Query>.MyTRefId { get => QueryId; /*set => Id = value;*/ }
    Query IReferences<Query>.MyTRef { get => Query; /*set => Query = value;*/ }
    int IReferences<Field>.MyTRefId { get => FieldId; /*set => Id = value;*/ }
    Field IReferences<Field>.MyTRef { get => Field; /*set => Field = value;*/ }
}





