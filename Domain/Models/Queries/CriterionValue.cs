
using Domain.Interfaces.Models;

namespace Domain.Models.Queries;

public class CriterionValue :  IIndexed, IReferences<Criterion>
{
    // Feed criterion with values.
    public int CriterionValueId { get; set; }
    public int CriterionId { get; set; }
    public Criterion Criterion { get; set; }
    public string Value { get; set; }
    /*
    public CriterionValue(Criterion criterion, string value)
    {
        Criterion = criterion;
        Value = value;
    }
    */
    int IIndexed.Id { get => CriterionValueId; set => CriterionValueId = value; }

    int IReferences<Criterion>.MyTRefId { get => CriterionId; /*set => CriterionId = value;*/ }
    Criterion IReferences<Criterion>.MyTRef { get => Criterion; /*set => Criterion = value;*/ }
}





