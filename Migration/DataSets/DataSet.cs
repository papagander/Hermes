using Domain.Interfaces.Models;

using System;

namespace Domain.Models.DataSets;

public class DataSet : Named, IReferencedBy<Field>
{
    public List<Field> Fields { get; set; }

    //public DataSet(string name)=> Name = name;

    List<Field> IReferencedBy<Field>.MyTs{get => Fields; }
}

