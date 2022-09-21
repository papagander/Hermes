using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.DataCore;

namespace Domain.Models;

public class Query
{
    public int QueryId;
    public string Name;
    public int DataSetId;
    public int StatementId;
    public List<Field> Fields;
    public Statement Statement;

}

public class Statement
{
    // A statement represents either a single criterion or a conjunction.
    // Each report points to a statement. Records for which the statement is true
    // are included in the report.
    [Key]
    public int Id;
    public int? ConjunctionId;
    public bool IsConjunction;
    public Conjunction? Conjunction;
    public Criterion? Criterion;
    public override string ToString()
    {
        if (IsConjunction) return Conjunction.ToString();
        else return Criterion.ToString();
    }
}
public class Conjunction
{
    // A Conjunction is pointed to by n statements (conjugants).
    // These statements are joined by the conjoiner
    // To form a higher statement, pointed to by the 
    // statement Id.
    public int ConjunctionId;
    public int ConjoinerId;
    public int StatementId;

    public Conjoiner Conjoiner;
    public Statement Statement;
    public List<Statement> Conjugants;

    public override string ToString()
    {
        string output = "";
        string conjoinerString = Conjoiner.Name;
        output += "(";
        for (int i = 0; i < Conjugants.Count; i++)
        {
            Statement? conjugant = Conjugants[i];
            output += $" {conjugant.ToString()}";
            if (i < Conjugants.Count - 1) output += $" {conjoinerString}";
        }
        output += ")";
        return output;
    }

}

public class Criterion
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Criterion are pointed to by CriterionValues to support n values per criterion.
    public int CriterionId;
    public int FieldId;
    public int OperatorId;
    public int StatementId;

    public Field Field;
    public Operator Operator;
    public Statement Statement;
    public List<CriterionValue> CriterionValues { get; set; }
    public override string ToString()
    {
        string output = "";
        output += $"{Field.Name} {Operator.Symbol} ";
        output += "{";
        for (int i = 0; i < CriterionValues.Count; i++)
        {
            CriterionValue? criterionValue = CriterionValues[i];
            output += " ";
            output += criterionValue.Value;
            output += ",";
        }
        output.Remove(output.Length - 1);
        output += " }";
        return output;
    }

}
public class CriterionValue
{
    // Feed criterion with values.
    [Key]
    public int CriterionValueId;
    [Required]
    public int CriterionId;
    public Criterion Criterion;
    public string Value;
}
public class QueryField
{
    // Create a link between a report and a field to be included on said report.
    public int QueryFieldId;
    public int QueryId;
    public int FieldId;
    public Query Query;
    public Field Field;
}





