
using Domain.Interfaces.Models;

namespace Domain.Models.Queries;

public class Statement :
    Indexed
    , ISuperTypeOf<Conjunction>
    , ISuperTypeOf<Criterion>
    , IReferences<Conjunction>
{
    // A statement represents either a single criterion or a conjunction.
    // Each report points to a statement. Records for which the statement is true
    // are included in the report.
    public override string ToString()
    {
        if (Conjunctions.Count == 1) return Conjunctions[1].ToString();
        else if (Criteria.Count == 1) return Criteria[0].ToString();
        return $"Unreferenced statement {Id}";
    }
    public int? ConjunctionId { get; set; }
    public Conjunction? Conjunction { get; set; }
    public List<Conjunction> Conjunctions
    {
        get => conjunctions;
        set
        {
            if (value.Count < 2 && (Criteria is null || Criteria.Count == 0)) conjunctions = value;
        }
    }
    public List<Criterion> Criteria
    {
        get => criteria;
        set
        {
            if (value.Count < 2 & (Conjunctions is null || Conjunctions.Count == 0) ) criteria = value;
        }
    }
    List<Criterion> criteria;
    private List<Conjunction> conjunctions;

    Criterion? ISuperTypeOf<Criterion>.MySub { get => Criteria[0]; }
    Conjunction? ISuperTypeOf<Conjunction>.MySub { get => Conjunctions[0]; }
    int IReferences<Conjunction>.MyTRefId { get { if (ConjunctionId is null) return -1; else return (int)ConjunctionId; } }
    Conjunction IReferences<Conjunction>.MyTRef { get => (Conjunction)Conjunction; }
}





