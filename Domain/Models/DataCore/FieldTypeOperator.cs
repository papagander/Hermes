using Domain.Interfaces.Models;

namespace Domain.Models.DataCore
{
    public class FieldTypeOperator : IReferences<FieldType>, IReferences<Operator>
    {
        // string contains, int less than,
        public int FieldTypeOperatorId { get; set; }
        public int FieldTypeId { get; set; }
        public int OperatorId { get; set; }
        public FieldType FieldType { get; set; }
        public Operator Operator { get; set; }
        /*
        public FieldTypeOperator(FieldType fieldType, Operator @operator)
        {
            FieldType = fieldType;
            Operator = @operator;
        }
        */
        int IReferences<FieldType>.MyTRefId { get { return FieldTypeId; } /*set { FieldTypeId = value; } */}
        FieldType IReferences<FieldType>.MyTRef { get { return FieldType; } /*set { FieldType = value; }*/ }
        int IReferences<Operator>.MyTRefId { get { return OperatorId; } /*set { OperatorId = value; }*/ }
        Operator IReferences<Operator>.MyTRef { get { return Operator; } /*set { Operator = value; }*/ }
        int IIndexed.Id { get => FieldTypeOperatorId; set => FieldTypeOperatorId = value;  }
    }

}

