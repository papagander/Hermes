using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class Report
{
    public int ReportId;
    public string Name;
    public int CustomerId;
    public int ReportTypeId;
    public int StatementId;
    public int TransmissionTypeId;
    public int MediumTypeId;

}
public class Template
{
    public int TemplateId;
    public string Name;
}
public class Field
{
    public int FieldId;
    public string Name;
    public int TemplateId;
    public int FieldTypeId;
}

public class FieldType
{
    public int FieldTypeId;
    public string Name;
}
public class Operator
{
    public int OperatorId;
    public string Name;
    public string? Symbol;
}
public class FieldTypeOperator
{
    public int FieldTypeOperatorId;
    public int FieldTypeId;
    public int OperatorId;
    public FieldType FieldType;
    public Operator Operator;
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
    public string ToString()
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
    [Key]
    public int ConjunctionId;
    [Required]
    public int ConjoinerId;
    [Required]
    public int StatementId;
    public Conjoiner Conjoiner;
    public Statement Statement;
    public List<Statement> Conjugants;
    public string ToString()
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

public class Conjoiner
{
    // e.g. AND, OR
    [Key]
    public int ConjoinerId;
    public string Name;

}

public class Criterion
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Criterion are pointed to by CriterionValues to support n values per criterion.
    [Key]
    public int CriterionId;
    [Required]
    public int FieldId;
    [Required]
    public int OperatorId;
    [Required]
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
        foreach (var criterionValue in CriterionValues)
        {
            output += " ";
            output += criterionValue.Value;
            output += ",";
        }
        output += "}";
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
public class ReportField
{
    // Create a link between a report and a field to be included on said report.
    [Key]
    public int ReportFieldId;
    [Required]
    public int ReportId;
    [Required]
    public int FieldId;
}





