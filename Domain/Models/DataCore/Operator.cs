using Domain.Interfaces.Models;

namespace Domain.Models.DataCore
{
    public class Operator : INamed, IReferencedBy<FieldType>, IReferencedBy<FieldTypeOperator>
    {
        // equals, greather than, less than, contains, etc.
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public List<FieldTypeOperator> FieldTypeOperators { get; set; }
        public List<FieldType> FieldTypes { get; set; }
        /*
        public Operator(string name)
        {
            OperatorName = name;
        }
        */
        string INamed.Name { get { return OperatorName; } set { OperatorName = value; } }

        List<FieldType>? IReferencedBy<FieldType>.MyTs { get { throw new NotImplementedException(); } }

        List<FieldTypeOperator> IReferencedBy<FieldTypeOperator>.MyTs { get => FieldTypeOperators; }
        int IIndexed.Id { get => OperatorId; set => OperatorId = value; }
    }

}

