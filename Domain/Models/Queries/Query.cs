
using Domain.Interfaces.Models;
using Domain.Models.DataSets;

namespace Domain.Models.Queries;

public class Query : INamed, IReferences<DataSet>, IReferencedBy<Field>
{
    public int QueryId { get; set; }
    public string QueryName { get; set; }
    public int DataSetId { get; set; }
    public int StatementId { get; set; }
    public DataSet DataSet { get; set; }
    public Statement Statement { get; set; }
    public List<Field> Fields { get; set; }

    /*
    public Query(string name, DataSet dataSet)
    {
        QueryName = name;
        DataSet = dataSet;
    }
    */
    string INamed.Name
    {
        get
        {
            return QueryName;
        }
        set
        {
            QueryName = value;
        }
    }
    int IIndexed.Id
    {
        get
        {
            return QueryId;
        }
        set
        {
            QueryId = value;
        }
    }
    int IReferences<DataSet>.MyTRefId { get => DataSetId; /*set => DataSetId = value;*/ }
    DataSet IReferences<DataSet>.MyTRef { get => DataSet; /*set => DataSet = value;*/ }
    List<Field>? IReferencedBy<Field>.MyTs { get => Fields; }
    //int IReferences<Statement>.MyTRefId { get => StatementId; /*set => StatementId = value;*/ }
    //Statement IReferences<Statement>.MyTRef { get => Statement; /*set => Statement = value;*/ }
}





