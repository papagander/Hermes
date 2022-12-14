using Domain.Interfaces.Models;
using Domain.Models.Generic;
using Domain.Models.Queries;

using System;

namespace Domain.Models.FieldSets;

public class FieldSet 
    : Named
    , IReferencedBy<Field>
    , IReferencedBy<Query>
{
    public override string ToString() => Name;
    
    public List<Field> Fields { get; set; }
    public List<Query> Queries { get; set; }
    List<Field> IReferencedBy<Field>.MyTs{ get => Fields; set => Fields = value; }
    List<Query> IReferencedBy<Query>.MyTs{ get => Queries; set => Queries= Queries; }
}

