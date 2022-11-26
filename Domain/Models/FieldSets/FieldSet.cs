using Domain.Interfaces.Models;
using Domain.Models.Generic;
using System;

namespace Domain.Models.FieldSets;

public class FieldSet : Named, IReferencedBy<Field>
{
    public override string ToString() => Name;
    
    public List<Field> Fields { get; set; }
    List<Field> IReferencedBy<Field>.MyTs{ get => Fields; set => Fields = value; }
}

