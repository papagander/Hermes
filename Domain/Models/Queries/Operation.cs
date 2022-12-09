
using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Queries;

public class Operation
    : Indexed
    , IReferences<Field>
    , IReferences<Operator>
    , IReferencedBy<OperationParameter>
    , ISubTypeOf<Statement>
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Operations are pointed to by CriterionParameter to support n values per criterion.
    public Statement ToStatement()
    {
        return new Statement() { Operation = this };
    }
    public override string ToString()
    {
        return ExecutionString;
        string output = "";
        output += $"{Field.Name} {Operator.Name} ";
        for (int i = 0; i < OperationParameters.Count; i++)
        {
            string nm = OperationParameters[i].Parameter.Name;
            string val = OperationParameters[i].Value;
            output += $"{nm}: {val} ";
        }
        output.Remove(output.Length - 1);
        return output;
    }
    [NotMapped]
    public string ExecutionString
    {
        get
        {
            // Get operator's default string
            string output = Operator.ExecutionString;
            // Add the field name
            output = output.Replace("/*FIELD_NAME*/", $"[{Field.Name}]");
            // Replace each parameter placeholder w its value
            for (int i = 0; i < OperationParameters.Count; i++)
            {
                OperationParameter? param = OperationParameters[i];
                output = output.Replace("/*p" + i + "*/", param.Value);
            }
            return output;
        }
    }
    public string FriendlyString
    {
        get
        {
            string output = Field.Name + " : " + Operator.Name;
            output += "(";
            var first = OperationParameters[0];
            output += first.Parameter.Name + " : ";
            output += first.Value;
            for (int i = 1; i < OperationParameters.Count; i++)
            {
                OperationParameter? param = OperationParameters[i];
                output += ", ";
                output += param.Parameter.Name + " : ";
                output += param.Value;
            }
            output += ")";

            return output;
        }
    }
    public Field Field { get; set; }
    public Operator Operator { get; set; }
    public Statement Statement { get; set; }
    public int FieldId { get; set; }
    public int OperatorId { get; set; }
    public int StatementId { get; set; }
    public List<OperationParameter> OperationParameters { get; set; }
    int IReferences<Field>.MyTRefId { get => FieldId; /*set => Id = value; */}
    Field IReferences<Field>.MyTRef { get => Field; /*set => Field = value;*/ }
    int IReferences<Operator>.MyTRefId { get => OperatorId; /*set => Id = value; */}
    Operator IReferences<Operator>.MyTRef { get => Operator; /*set => Operator = value; */}
    Statement ISubTypeOf<Statement>.MySuper { get => Statement; set => Statement = value; }
    int ISubTypeOf<Statement>.MySuperId { get => StatementId; set => StatementId = value; }
    List<OperationParameter> IReferencedBy<OperationParameter>.MyTs { get => OperationParameters; set => OperationParameters = value; }
}





