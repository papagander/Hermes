
using Domain.Interfaces.Models;
using Domain.Models.DataCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Queries;

public class Conjunction : IIndexed, ISubTypeOf<Statement>, IReferences<Conjoiner>, IReferencedBy<Statement>
{
    // A Conjunctions is pointed to by n statements (conjugants).
    // These statements are joined by the conjoiner
    // To form a higher statement, pointed to by the 
    // statement Id.
    public int ConjunctionId { get; set; }
    public int ConjoinerId { get; set; }
    public int StatementId { get; set; }

    public Conjoiner Conjoiner { get; set; }
    [NotMapped]
    public Statement Statement { get; set; }
    [NotMapped]
    public List<Statement> Statements { get; set; }

    public override string ToString()
    {
        string output = "";
        string conjoinerString = Conjoiner.ConjoinerName;
        output += "(";
        for (int i = 0; i < Statements.Count; i++)
        {
            Statement conjugant = Statements[i];
            output += $" {conjugant.ToString()}";
            if (i < Statements.Count - 1) output += $" {conjoinerString}";
        }
        output += ")";
        return output;
    }
    int IIndexed.Id
    {
        get
        {
            return ConjunctionId;
        }
        set
        {
            ConjunctionId = value;
        }
    }
    int ISubTypeOf<Statement>.MySuperId { get => StatementId; set => StatementId = value; }
    Statement ISubTypeOf<Statement>.MySuper { get => Statement; set => Statement = value; }
    int IReferences<Conjoiner>.MyTRefId { get => ConjoinerId; /*set => ConjoinerId = value;*/ }
    Conjoiner IReferences<Conjoiner>.MyTRef { get => Conjoiner; /*set => Conjoiner = value;*/ }
    List<Statement> IReferencedBy<Statement>.MyTs { get => Statements; }
}





