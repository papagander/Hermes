using Domain.Interfaces.Models;

namespace Domain.Models.DataCore
{
    public class Operator : Named, IReferencedBy<FieldType>, IReferencedBy<FieldTypeOperator>
    {
        // equals, greather than, less than, contains, etc.
        public List<FieldTypeOperator> FieldTypeOperators { get; set; }
        public List<FieldType> FieldTypes { get; set; }

        List<FieldType> IReferencedBy<FieldType>.MyTs { get { throw new NotImplementedException(); } }

        List<FieldTypeOperator> IReferencedBy<FieldTypeOperator>.MyTs { get => FieldTypeOperators; }
    }

}

