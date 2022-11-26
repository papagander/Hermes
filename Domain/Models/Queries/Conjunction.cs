
using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Queries;

public class Conjunction : Indexed, ISubTypeOf<Statement>, IReferences<Conjoiner>, IReferencedBy<Statement>
{
    // A ParentConjunction is pointed to by n statements (conjugants).
    // These statements are joined by the conjoiner
    // To form a higher statement, pointed to by the 
    // statement Id.
    public Statement ToStatement()
    {
        Statement stat = new();
        stat.Conjunction = this;
        return stat;
    }
    public override string ToString()
    {
        string output = "";
        string conjoinerString = Conjoiner.Name;
        output += "(";
        for (int i = 0; i < Statements.Count; i++)
        {
            Statement conjugant = Statements[i];
            output += $" {conjugant}";
            if (i < Statements.Count - 1) output += $" {conjoinerString}";
        }
        output += ")";
        return output;
    }
    public int ConjoinerId { get; set; }
    public int StatementId { get; set; }

    public Conjoiner Conjoiner { get; set; }
    public Statement Statement { get; set; }
    public List<Statement> Statements { get; set; }
    int ISubTypeOf<Statement>.MySuperId { get => StatementId; set => StatementId = value; }
    Statement ISubTypeOf<Statement>.MySuper { get => Statement; set => Statement = value; }
    int IReferences<Conjoiner>.MyTRefId { get => ConjoinerId; /*set => Id = value;*/ }
    Conjoiner IReferences<Conjoiner>.MyTRef { get => Conjoiner; /*set => Conjoiner = value;*/ }
    List<Statement> IReferencedBy<Statement>.MyTs { get => Statements; set => Statements = value; }
}





