
using Domain.Interfaces.Models;
using Domain.Models.DataCore;
using Domain.Models.DataSets;

namespace Domain.Models.Queries;

public class Criterion : Indexed, IReferences<Field>, IReferences<Operator>, ISubTypeOf<Statement>, IReferencedBy<CriterionValue>
{
    // e.g. Serial number equals, DateReceived greater than, Model Number contains.
    // Criterions are pointed to by CriterionValues to support n values per criterion.
    public override string ToString()
    {
        string output = "";
        output += $"{Field.Name} {Operator.Name} ";
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
    public int FieldId { get; set; }
    public int OperatorId { get; set; }
    public int StatementId { get; set; }

    public Field Field { get; set; }
    public Operator Operator { get; set; }
    public Statement Statement { get; set; }
    public List<CriterionValue> CriterionValues { get; set; }
    int IReferences<Field>.MyTRefId { get => FieldId; /*set => Id = value; */}
    Field IReferences<Field>.MyTRef { get => Field; /*set => Field = value;*/ }
    int IReferences<Operator>.MyTRefId { get => OperatorId; /*set => Id = value; */}
    Operator IReferences<Operator>.MyTRef { get => Operator; /*set => Operator = value; */}
    Statement ISubTypeOf<Statement>.MySuper { get => Statement; set => Statement = value; }
    int ISubTypeOf<Statement>.MySuperId { get => StatementId; set => StatementId = value; }
    List<CriterionValue> IReferencedBy<CriterionValue>.MyTs { get => CriterionValues; }
}





