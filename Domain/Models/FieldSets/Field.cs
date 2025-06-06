﻿using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Generic;
using Domain.Models.Queries;

using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.FieldSets;

public class Field : Named, IReferences<FieldSet>
{
    public override string ToString()
    {

        if (FieldSet is not null) return $"{FieldSet.Name}.{Name} ({DbType.ToString()})";
        else return Name;
    }
    [NotNull]
    public int FieldSetId { get; set; }
    [NotNull]
    public SqlDbType DbType { get; set; }
    public FieldSet FieldSet { get; set; }
    internal List<Query> Queries { get; set; }
    int IReferences<FieldSet>.MyTRefId { get => FieldSetId;  /*set => Id = value;  */}
    FieldSet IReferences<FieldSet>.MyTRef { get => FieldSet; /*set => FieldSet = value;*/ }
}

