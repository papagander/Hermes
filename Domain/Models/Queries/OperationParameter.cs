
using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Generic;

namespace Domain.Models.Queries;

public class OperationParameter
    : Indexed
    , IReferences<Operation>
    , IReferences<Parameter>
{
    public override string ToString() => Value;
    // Feed criterion with values.
    public int OperationId { get; set; }
    public int ParameterId { get; set; }
    public Operation Operation { get; set; }
    public Parameter Parameter { get; set; }
    public string Value { get; set; }
    int IReferences<Operation>.MyTRefId { get => OperationId; }
    Operation IReferences<Operation>.MyTRef { get => Operation; }
    Parameter IReferences<Parameter>.MyTRef { get => Parameter; }
    int IReferences<Parameter>.MyTRefId { get => ParameterId; }
}