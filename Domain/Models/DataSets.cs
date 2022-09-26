using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Queries;

using System;

namespace Domain.Models.DataSets;

public class DataSet : INamed, IReferencedBy<Field>
{
    public int DataSetId;
    public string DataSetName;
    public List<Field> Fields;
    string INamed.Name { get { return DataSetName; } set { DataSetName = value; } }
    int IIndexed.Id { get { return DataSetId; } set { DataSetId = value; } }

    public DataSet(string name)=> DataSetName = name;

    List<Field> IReferencedBy<Field>.MyTs{get => Fields; }
}
public class Field : INamed, IReferences<DataSet>, IReferences<FieldType>, IReferencedBy<Query>
{
    public int FieldId;
    public string FieldName;
    public int DataSetId;
    public int FieldTypeId;
    public FieldType FieldType;
    public DataSet DataSet;
    private List<QueryField> queryFields;
    public Field(FieldType fieldType, DataSet dataSet, string name)
    {
        FieldType = fieldType;
        DataSet = dataSet;
        FieldName = name;
    }
    string INamed.Name { get => FieldName; set => FieldName = value;  }
    int IIndexed.Id { get { return FieldId; } set { FieldId = value; } }
    int IReferences<DataSet>.MyTRefId { get => DataSetId;  /*set => DataSetId = value;  */}
    int IReferences<FieldType>.MyTRefId { get =>FieldTypeId; /*set => FieldTypeId = value;*/ }
    DataSet IReferences<DataSet>.MyTRef { get => DataSet; /*set => DataSet = value;*/ }
    FieldType IReferences<FieldType>.MyTRef { get => FieldType; /*set => FieldType = value;*/ }
    List<Query> IReferencedBy<Query>.MyTs
    { 
        get 
        { 
            List<Query> queries = new List<Query>();
            foreach (QueryField queryField in queryFields) queries.Add(queryField.Query);
            return queries;
        } 
    }
}

