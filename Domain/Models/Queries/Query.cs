
using Domain.Interfaces.Models;
using Domain.Models.DataSets;

namespace Domain.Models.Queries;

public class Query : Named, IReferences<DataSet>, IReferencedBy<Field>
{
    public override string ToString() => $"{DataSet.Name}.{Name}";
    public int DataSetId { get; set; }
    public int StatementId { get; set; }
    public DataSet DataSet { get; set; }
    public Statement Statement { get; set; }
    public List<Field> Fields { get; set; }
    int IReferences<DataSet>.MyTRefId { get => DataSetId; /*set => Id = value;*/ }
    DataSet IReferences<DataSet>.MyTRef { get => DataSet; /*set => DataSet = value;*/ }
    List<Field> IReferencedBy<Field>.MyTs { get => Fields; set => Fields = value; }
    //int IReferences<Statement>.MyTRefId { get => Id; /*set => Id = value;*/ }
    //Statement IReferences<Statement>.MyTRef { get => Statement; /*set => Statement = value;*/ }
}





