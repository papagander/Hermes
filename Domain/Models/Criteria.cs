using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class Statement
{
    // A statement represents either a single criterion or a conjunction.
    // Each report points to a statement. Records for which the statement is true
    // are included in the report.
    [Key]
    public int Id;
    // 
    Conjuction? ParentConjuction;
    public int? Conjunctionid;

    public Statement(int? parentConjunctionid)
    {
        Conjunctionid = parentConjunctionid;
    }
}
public class Conjuction
{
    // A Conjunction is pointed to by n statements (conjugants).
    // These statements are joined by the conjoiner
    // To form a higher statement, pointed to by the 
    // statement Id.
    [Key]
    public int ConjunctionId;
    [Required]
    public int ConjoinerId;
    public Conjoiner Conjoiner;
    [Required]
    public int StatementId;
    public Statement Statement;
    public List<Statement> Conjugants;

    public Conjuction(int conjunctionId, int conjoinerId, int statementId)
    {
        ConjunctionId = conjunctionId;
        ConjoinerId = conjoinerId;
        StatementId = statementId;
    }
}

public class Conjoiner
{
    // e.g. AND, OR
    [Key]
    public int ConjoinerId;
    public string ConjoinerName;

    public Conjoiner(string conjoinerName)
    {
        ConjoinerName = conjoinerName;
    }
}

public class Criterion
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Criterion are pointed to by CriterionValues to support n values per criterion.
    [Key]
    public int CriterionId;
    public Field Field;
    [Required]
    public int FieldId;
    public Operator Operation;
    [Required]
    public int OperationId;
    public Statement Statement;
    [Required]
    public int StatementId;

}
public class CriterionValue
{
    // Feed criterion with values.
    [Key]
    public int CriterionValueId;
    public Criterion Criterion;
    [Required]
    public int CriterionId;
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
