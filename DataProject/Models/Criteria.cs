using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class Statement
{
    // Each statement represents a fact which is either true or false per row of the data source.
    // Each statement is pointed to by exactly one criterion OR exactly one conjunction,
    // which it represents.
    // Records for which the top-level statement is true are returned
    // by the query.
    int Id;
    Conjuction ParentConjuction;
    int ParentConjunctionid;

}
public class Conjuction
{
    // A Conjunction is pointed to by n statements (conjugants).
    // These statements are joined by the conjoiner
    // To form a higher statement, pointed to by the 
    // statement Id.
    public int ConjunctionId;
    public Conjoiner Conjoiner;
    public int ConjoinerId;
    public Statement Statement;
    public int StatementId;
    public List<Statement> Conjugants;   
}

public class Conjoiner
{
    // e.g. AND, OR
    public int ConjoinerId;
    public string ConjoinerName;
}

public class Criterion
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Criterion are pointed to by CriterionValues to support n values per criterion.
    public int CriterionId;
    public Field Field;
    public int FieldId;
    public Operation Operation;
    public int OperationId;
    public Statement Statement;
    public int StatementId;

}
public class CriterionValue
{
    // Feed criterion with values.
    public int CriterionValueId;
    public Criterion Criterion;
    public int CriterionId;
    public string Value;
}
