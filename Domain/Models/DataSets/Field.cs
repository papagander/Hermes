using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Queries;

namespace Domain.Models.DataSets;

public class Field : Named, IReferences<DataSet>, IReferences<FieldType>, IReferencedBy<Query>
{
    public override string ToString() => $"{DataSet.Name}.{Name}";
    public int DataSetId { get; set; }
    public int FieldTypeId { get; set; }
    public FieldType FieldType { get; set; }
    public DataSet DataSet { get; set; }
    private List<QueryField> queryFields { get; set; }
    int IReferences<DataSet>.MyTRefId { get => DataSetId;  /*set => Id = value;  */}
    int IReferences<FieldType>.MyTRefId { get =>FieldTypeId; /*set => Id = value;*/ }
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

