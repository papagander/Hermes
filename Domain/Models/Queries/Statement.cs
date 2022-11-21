
using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

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
        if (Conjunction is not null) return Conjunction.ToString();
        else if (Operation is not null) return Operation.ToString();
        else return $"Unreferenced statement {Id}";
    }
    [NotMapped]
    public Operation? Operation 
    { 
        get 
        { 
            if (operations is null)
                return null; 
            return operations[0]; 
        }
        set 
        {
            if (Conjunction is null)
            {
                operations= new();
                operations.Add(value);
            }
            else throw new Exception("Statement cannot reference both an operation and a conjunction.");
        } 
    }
    [NotMapped]
    public Conjunction? Conjunction
    {
        get 
        {
            if (conjunctions is null) 
                return null; 
            return conjunctions[0]; 
        }
        set
        {
            if (Operation is null)
            {
                conjunctions = new();
                conjunctions.Add(value);
            }
            else throw new Exception("Statement cannot reference both an operation and a conjunction.");
        }
    }
    public int? ParentConjunctionId { get; set; }
    public Conjunction? ParentConjunction { get; set; }
    internal List<Operation> operations;
    internal List<Conjunction> conjunctions;

    Operation? ISuperTypeOf<Operation>.MySub { get => Operation; }
    Conjunction? ISuperTypeOf<Conjunction>.MySub { get => Conjunction; }
    int IReferences<Conjunction>.MyTRefId { get { if (ParentConjunctionId is null) return -1; else return (int)ParentConjunctionId; } }
    Conjunction IReferences<Conjunction>.MyTRef { get => (Conjunction)ParentConjunction; }
}