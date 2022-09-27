using Domain.Interfaces.Models;

using System;

namespace Domain.Models.DataSets;

public class DataSet : INamed, IReferencedBy<Field>
{
    public int DataSetId { get; set; }
    public string DataSetName { get; set; }
    public List<Field> Fields { get; set; }
    string INamed.Name { get => DataSetName;  set { DataSetName = value; } }
    int IIndexed.Id { get  => DataSetId;  set { DataSetId = value; } }

    //public DataSet(string name)=> DataSetName = name;

    List<Field> IReferencedBy<Field>.MyTs{get => Fields; }
}

