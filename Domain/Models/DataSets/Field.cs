using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Queries;

namespace Domain.Models.DataSets;

public class Field : INamed, IReferences<DataSet>, IReferences<FieldType>, IReferencedBy<Query>
{
    public int FieldId { get; set; }
    public string FieldName { get; set; }
    public int DataSetId { get; set; }
    public int FieldTypeId { get; set; }
    public FieldType FieldType { get; set; }
    public DataSet DataSet { get; set; }
    private List<QueryField> queryFields { get; set; }
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

