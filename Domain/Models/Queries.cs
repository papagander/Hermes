using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interfaces.Model;
using Domain.Models.DataCore;

namespace Domain.Models;

public class Query : INamed, IReferenceTable<DataSet>, IReferenceTable<Statement>
{
    public int QueryId;
    public string QueryName;
    public int DataSetId;
    public int StatementId;
    public DataSet DataSet;
    public Statement Statement;
    public List<Field> Fields;

    public Query(string name, DataSet dataSet)
    {
        QueryName = name;
        DataSet = dataSet;
    }

    string INamed.Name
    {
        get
        {
            return QueryName;
        }
        set
        {
            QueryName = value;
        }
    }
    int IIndexed.Id
    {
        get
        {
            return QueryId;
        }
        set
        {
            QueryId = value;
        }
    }
    int IReferenceTable<DataSet>.TId { get => DataSetId; set => DataSetId = value; }
    DataSet IReferenceTable<DataSet>.MyT { get => DataSet; set => DataSet = value; }
    int IReferenceTable<Statement>.TId { get => StatementId; set => StatementId = value; }
    Statement IReferenceTable<Statement>.MyT { get => Statement; set => Statement = value; }
}

public class Statement : IIndexed
{
    // A statement represents either a single criterion or a conjunction.
    // Each report points to a statement. Records for which the statement is true
    // are included in the report.
    public int StatementId;
    public int? ConjunctionId;
    public bool IsConjunction;
    public Conjunction? Conjunction;
    public List<Conjunction> Conjunctions;
    public List<Criterion> Criterions;


    public override string ToString()
    {
        if (IsConjunction) return Conjunction.ToString();
        else return Criterion.ToString();
    }
    int IIndexed.Id { get => StatementId; set => StatementId = value; }
}
public class Conjunction : IIndexed, IReferenceTable<Statement>, IReferenceTable<Conjoiner>
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
        string conjoinerString = Conjoiner.ConjoinerName;
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
    int IReferenceTable<Statement>.TId { get => StatementId; set => StatementId = value; }
    Statement IReferenceTable<Statement>.MyT { get => Statement; set => Statement = value; }
    int IReferenceTable<Conjoiner>.TId { get => ConjoinerId; set => ConjoinerId = value; }
    Conjoiner IReferenceTable<Conjoiner>.MyT { get => Conjoiner; set => Conjoiner = value; }

}

public class Criterion : IIndexed, IReferenceTable<Field>, IReferenceTable<Operator>, IReferenceTable<Statement>, IReferencedTable<CriterionValue>
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
    int IIndexed.Id
    {
        get
        {
            return CriterionId;
        }
        set
        {
            CriterionId = value;
        }
    }
    int IReferenceTable<Field>.TId { get => FieldId; set => FieldId = value; }
    Field IReferenceTable<Field>.MyT { get => Field; set => Field = value; }
    int IReferenceTable<Operator>.TId { get => OperatorId; set => OperatorId = value; }
    Operator IReferenceTable<Operator>.MyT { get => Operator; set => Operator = value; }
    int IReferenceTable<Statement>.TId { get => StatementId; set => StatementId = value; }
    Statement IReferenceTable<Statement>.MyT { get => Statement; set => Statement = value; }
    List<CriterionValue> IReferencedTable<CriterionValue>.MyTs { get => CriterionValues; set => CriterionValues = value; }
}
public class CriterionValue : IValued, IReferenceTable<Criterion>
{
    // Feed criterion with values.
    [Key]
    public int CriterionValueId;
    [Required]
    public int CriterionId;
    public Criterion Criterion;
    public string Value;

    public CriterionValue(Criterion criterion, string value)
    {
        Criterion = criterion;
        Value = value;
    }

    int IIndexed.Id { get => CriterionValueId; set => CriterionValueId = value; }

    string IValued.Value { get => Value; set => Value = value; }
    int IReferenceTable<Criterion>.TId { get => CriterionId; set => CriterionId = value; }
    Criterion IReferenceTable<Criterion>.MyT { get => Criterion; set => Criterion = value; }
}
public class QueryField : IIndexed, IReferenceTable<Query>, IReferenceTable<Field>
{
    // Create a link between a report and a field to be included on said report.
    public int QueryFieldId;
    public int QueryId;
    public int FieldId;
    public Query Query;
    public Field Field;

    public QueryField(Query query, Field field)
    {
        Query = query;
        Field = field;
    }

    int IIndexed.Id { get => QueryFieldId; set => QueryFieldId = value; }
    int IReferenceTable<Query>.TId { get => QueryId; set => QueryId = value; }
    Query IReferenceTable<Query>.MyT { get => Query; set => Query = value; }
    int IReferenceTable<Field>.TId { get => FieldId; set => FieldId = value; }
    Field IReferenceTable<Field>.MyT { get => Field; set => Field = value; }
}





