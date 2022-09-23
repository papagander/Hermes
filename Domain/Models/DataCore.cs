using Domain.Interfaces.Models;

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DataCore
{

    public class FieldType : INamed, IReferencedBy<Operator>
    {
        // string, int, date, money?
        public int FieldTypeId;
        public string FieldTypeName;
        public readonly List<FieldTypeOperator> fieldTypeOperators;
        public List<Operator> Operators;
        public FieldType(string name)
        {
            Name = name;
        }
        public int Id { get { return FieldTypeId; } set { FieldTypeId = value; } }
        public string Name { get { return FieldTypeName; } set { FieldTypeName = value; } }

        List<Operator> IReferencedBy<Operator>.MyTs
        {
            get
            {
                List<Operator> operators = new List<Operator>();
                foreach (FieldTypeOperator fieldTypeOperator in fieldTypeOperators) operators.Add(fieldTypeOperator.Operator);
                return operators;
            }
        }
        int IIndexed.Id { get { return FieldTypeId; } set { FieldTypeId = value; } }
    }
    public class Operator : INamed, IReferencedBy<FieldType>
    {
        // equals, greather than, less than, contains, etc.
        public int OperatorId;
        public string OperatorName;
        public List<FieldTypeOperator> fieldTypeOperators;
        public List<FieldType> FieldTypes;

        public Operator(string name)
        {
            OperatorName = name;
        }

        string INamed.Name { get { return OperatorName; } set { OperatorName = value; } }

        List<FieldType>? IReferencedBy<FieldType>.MyTs { get { throw new NotImplementedException(); } }
        int IIndexed.Id { get => OperatorId; set => OperatorId = value; }
    }
    public class FieldTypeOperator : IReferences<FieldType>, IReferences<Operator>
    {
        // string contains, int less than,
        public int FieldTypeOperatorId;
        public int FieldTypeId;
        public int OperatorId;
        public FieldType FieldType;
        public Operator Operator;

        public FieldTypeOperator(FieldType fieldType, Operator @operator)
        {
            FieldType = fieldType;
            Operator = @operator;
        }

        int IReferences<FieldType>.MyTRefId { get { return FieldTypeId; } /*set { FieldTypeId = value; } */}
        FieldType IReferences<FieldType>.MyTRef { get { return FieldType; } /*set { FieldType = value; }*/ }
        int IReferences<Operator>.MyTRefId { get { return OperatorId; } /*set { OperatorId = value; }*/ }
        Operator IReferences<Operator>.MyTRef { get { return Operator; } /*set { Operator = value; }*/ }
        int IIndexed.Id { get => FieldTypeOperatorId; set => FieldTypeOperatorId = value;  }
    }

    public class Conjoiner : INamed
    {
        // AND, OR
        public int ConjoinerId;
        public string ConjoinerName;

        public Conjoiner(string name)
        {
            ConjoinerName = name;
        }

        string INamed.Name { get { return ConjoinerName; } set { ConjoinerName = value; } }
        int IIndexed.Id { get { return ConjoinerId; } set { ConjoinerId = value; } }
    }

}

