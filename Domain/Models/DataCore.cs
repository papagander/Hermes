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
        public List<Operator> Operators;
        public FieldType(string name)
        {
            Name = name;
        }
        public int Id { get { return FieldTypeId; } set { FieldTypeId = value; } }
        public string Name { get { return FieldTypeName; } set { FieldTypeName = value; } }

        List<Operator> IReferencedBy<Operator>.MyTs { get => Operators; set => Operators = value; }
        int IIndexed.Id { get { return FieldTypeId; } set { FieldTypeId = value; } }
    }
    public class Operator : INamed
    {
        // equals, greather than, less than, contains, etc.
        public int OperatorId;
        public string OperatorName;
        public List<FieldType> FieldTypes;

        public Operator(string name)
        {
            OperatorName = name;
        }

        public int Id { get { return OperatorId; } set { OperatorId = value; } }
        public string Name { get { return OperatorName; } set { OperatorName = value; } }
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

        int IReferences<FieldType>.TDex { get { return FieldTypeId; } set { FieldTypeId = value; } }
        FieldType IReferences<FieldType>.MyT { get { return FieldType; } set { FieldType = value; } }
        int IReferences<Operator>.TDex { get { return OperatorId; } set { OperatorId = value; } }
        Operator IReferences<Operator>.MyT { get { return Operator; } set { Operator = value; }  }
        int IIndexed.Id { get { return FieldTypeOperatorId; } set { FieldTypeOperatorId = value; } }
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

