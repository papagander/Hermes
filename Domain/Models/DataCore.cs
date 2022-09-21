using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DataCore
{

    public class FieldType
    {
        // string, int, date, money?
        public int FieldTypeId;
        public string Name;
        public List<Operator> Operators;
    }
    public class Operator
    {
        // equals, greather than, less than, contains, etc.
        public int OperatorId;
        public string Name;
        public string? Symbol;
        public List<FieldType> FieldTypes;
    }
    public class FieldTypeOperator
    {
        // string contains, int less than,
        public int FieldTypeOperatorId;
        public int FieldTypeId;
        public int OperatorId;
        public FieldType FieldType;
        public Operator Operator;
    }

    public class Conjoiner
    {
        // AND, OR
        public int ConjoinerId;
        public string Name;

    }

}

