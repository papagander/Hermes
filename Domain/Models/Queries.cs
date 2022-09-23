using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using Domain.Interfaces.Models;
using Domain.Models.DataCore;

namespace Domain.Models;

public class Query : INamed, IReferences<DataSet>, IReferences<Statement>
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
    int IReferences<DataSet>.TDex { get => DataSetId; set => DataSetId = value; }
    DataSet IReferences<DataSet>.MyT { get => DataSet; set => DataSet = value; }
    int IReferences<Statement>.TDex { get => StatementId; set => StatementId = value; }
    Statement IReferences<Statement>.MyT { get => Statement; set => Statement = value; }
}

public class Statement : IIndexed, ISuperTypeOf<Conjunction> , ISuperTypeOf<Criterion>
{
    // A statement represents either a single criterion or a conjunction.
    // Each report points to a statement. Records for which the statement is true
    // are included in the report.
    public int StatementId;
    public int? ParentConjunctionId;
    public Conjunction? ParentConjunction;
    public List<Conjunction> Conjunctions;
    public List< Criterion> Criterions;


    public override string ToString()
    {
        if (Conjunctions.Count == 1) return Conjunctions[0].ToString();
        else if (Criterions.Count == 1) return Criterions[0].ToString();
        return $"Unreferenced statement {StatementId}";
    }
    int IIndexed.Id { get => StatementId; set => StatementId = value; }
    Criterion? ISuperTypeOf<Criterion>.MySub { get => Criterions[0];  }
    Conjunction? ISuperTypeOf<Conjunction>.MySub { get => Conjunctions[0]; }
}
public class Conjunction : IIndexed, ISubTypeOf<Statement>, IReferences<Conjoiner>
{
    // A Conjunctions is pointed to by n statements (conjugants).
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
    int ISubTypeOf<Statement>.SuperDex { get => StatementId; set => StatementId = value; }
    Statement ISubTypeOf<Statement>.MySuper { get => Statement; set => Statement = value; }
    int IReferences<Conjoiner>.TDex { get => ConjoinerId; set => ConjoinerId = value; }
    Conjoiner IReferences<Conjoiner>.MyT { get => Conjoiner; set => Conjoiner = value; }

}

public class Criterion : IIndexed, IReferences<Field>, IReferences<Operator>, IReferences<Statement>, IReferencedBy<CriterionValue>
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Criterions are pointed to by CriterionValues to support n values per criterion.
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
        output += $"{Field.FieldName} {Operator.} ";
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
    int IReferences<Field>.TDex { get => FieldId; set => FieldId = value; }
    Field IReferences<Field>.MyT { get => Field; set => Field = value; }
    int IReferences<Operator>.TDex { get => OperatorId; set => OperatorId = value; }
    Operator IReferences<Operator>.MyT { get => Operator; set => Operator = value; }
    int IReferences<Statement>.TDex { get => StatementId; set => StatementId = value; }
    Statement IReferences<Statement>.MyT { get => Statement; set => Statement = value; }
    List<CriterionValue> IReferencedBy<CriterionValue>.MyTs { get => CriterionValues; }
}
public class CriterionValue : INamed, IReferences<Criterion>
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

    string INamed.Name { get => Value; set => Value = value; }
    int IReferences<Criterion>.TDex { get => CriterionId; set => CriterionId = value; }
    Criterion IReferences<Criterion>.MyT { get => Criterion; set => Criterion = value; }
}
public class QueryField : IIndexed, IReferences<Query>, IReferences<Field>
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
    int IReferences<Query>.TDex { get => QueryId; set => QueryId = value; }
    Query IReferences<Query>.MyT { get => Query; set => Query = value; }
    int IReferences<Field>.TDex { get => FieldId; set => FieldId = value; }
    Field IReferences<Field>.MyT { get => Field; set => Field = value; }
}





