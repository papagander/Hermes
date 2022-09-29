
using Domain.Interfaces.Models;

namespace Domain.Models.Queries;

public class CriterionValue :  Indexed, IReferences<Criterion>
{
    public override string ToString() => Value;
    // Feed criterion with values.
    public int CriterionId { get; set; }
    public Criterion Criterion { get; set; }
    public string Value { get; set; }
    int IReferences<Criterion>.MyTRefId { get => CriterionId; /*set => Id = value;*/ }
    Criterion IReferences<Criterion>.MyTRef { get => Criterion; /*set => Criterion = value;*/ }
}





