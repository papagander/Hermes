using Domain.Interfaces.Models;

namespace Domain.Models.DataCore
{
    public class FieldType : INamed, IReferencedBy<Operator>, IReferencedBy<FieldTypeOperator>
    {
        // string, int, date, money?
        public int FieldTypeId { get; set; }
        public string FieldTypeName { get; set; }
        public List<FieldTypeOperator> FieldTypeOperators { get; set; }
        public List<Operator> Operators { get; set; }
        /*
        public FieldType(string name)
        {
            Name = name;
        }
        */
        public int Id { get { return FieldTypeId; } set { FieldTypeId = value; } }
        public string Name { get { return FieldTypeName; } set { FieldTypeName = value; } }

        List<Operator> IReferencedBy<Operator>.MyTs
        {
            get
            {
                List<Operator> operators = new List<Operator>();
                foreach (FieldTypeOperator fieldTypeOperator in FieldTypeOperators) operators.Add(fieldTypeOperator.Operator);
                return operators;
            }
        }

        List<FieldTypeOperator> IReferencedBy<FieldTypeOperator>.MyTs { get => FieldTypeOperators; }

        int IIndexed.Id { get { return FieldTypeId; } set { FieldTypeId = value; } }
    }

}

