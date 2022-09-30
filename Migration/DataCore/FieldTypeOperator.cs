using Domain.Interfaces.Models;

namespace Domain.Models.DataCore
{
    public class FieldTypeOperator : 
        Indexed
        , IReferences<FieldType>
        , IReferences<Operator>
    {
        public override string ToString() => $"{FieldType.ToString()}\t{Operator.ToString()}";
        // string contains, int less than,
        public int FieldTypeId { get; set; }
        public int OperatorId { get; set; }
        public FieldType FieldType { get; set; }
        public Operator Operator { get; set; }
        int IReferences<FieldType>.MyTRefId { get { return FieldTypeId; } /*set { Id = value; } */}
        FieldType IReferences<FieldType>.MyTRef { get { return FieldType; } /*set { FieldType = value; }*/ }
        int IReferences<Operator>.MyTRefId { get { return OperatorId; } /*set { Id = value; }*/ }
        Operator IReferences<Operator>.MyTRef { get { return Operator; } /*set { Operator = value; }*/ }
    }

}

