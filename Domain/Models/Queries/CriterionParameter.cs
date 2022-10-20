
using Domain.Interfaces.Models;
using Domain.Models.DataCore;

namespace Domain.Models.Queries;

public class CriterionParameter 
    :  Indexed
    , IReferences<Criterion>
    , IReferences<Parameter>
{
    public override string ToString() => Value;
    // Feed criterion with values.
    public int CriterionId { get; set; }
    public int ParameterId { get; set; }
    public Criterion Criterion { get; set; }
    public Parameter Parameter { get; set; }
    public string Value { get => Value; set 
        {
            Value = value;
        }
    }
    int IReferences<Criterion>.MyTRefId { get => CriterionId;  }
    Criterion IReferences<Criterion>.MyTRef { get => Criterion; }
    Parameter IReferences<Parameter>.MyTRef { get => Parameter; }
    int IReferences<Parameter>.MyTRefId { get => ParameterId; }
}