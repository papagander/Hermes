
using Domain.Interfaces.Models;

namespace Domain.Models.Queries;

public class Statement
    : Indexed
    , ISuperTypeOf<Conjunction>
    , ISuperTypeOf<Operation>
    , IReferences<Conjunction>
{
    // A statement represents either a single criterion or a conjunction.
    // Each report points to a statement. Records for which the statement is true
    // are included in the report.
    public override string ToString()
    {
        if (Conjunctions is not null && Conjunctions.Count > 0) return Conjunctions[0].ToString();
        else if (Operations is not null && Operations.Count > 0) return Operations[0].ToString();
        else return $"Unreferenced statement {Id}";
    }
    public int? ConjunctionId { get; set; }
    public Conjunction? Conjunction { get; set; }
    public List<Conjunction> Conjunctions
    {
        get => conjunctions;
        set
        {
            if (value.Count < 2 && (Operations is null || Operations.Count == 0)) conjunctions = value;
        }
    }
    public List<Operation> Operations
    {
        get => operations;
        set
        {
            if (value.Count < 2 & (Conjunctions is null || Conjunctions.Count == 0)) operations = value;
        }
    }
    List<Operation> operations;
    private List<Conjunction> conjunctions;

    Operation? ISuperTypeOf<Operation>.MySub { get => Operations[0]; }
    Conjunction? ISuperTypeOf<Conjunction>.MySub { get => Conjunctions[0]; }
    int IReferences<Conjunction>.MyTRefId { get { if (ConjunctionId is null) return -1; else return (int)ConjunctionId; } }
    Conjunction IReferences<Conjunction>.MyTRef { get => (Conjunction)Conjunction; }
}