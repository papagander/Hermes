using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class Operator : Named, IReferencedBy<FieldType>, IReferencedBy<FieldTypeOperator>
    {
        // equals, greather than, less than, contains, etc.
        public List<FieldTypeOperator> FieldTypeOperators { get; set; }
        [NotMapped]
        public List<FieldType> FieldTypes
        {
            get
            {
                var fieldTypes = new List<FieldType>();
                foreach (FieldTypeOperator fto in FieldTypeOperators) fieldTypes.Add(fto.FieldType);
                return fieldTypes;
            }
        }

        List<FieldType> IReferencedBy<FieldType>.MyTs { get => FieldTypes; }

        List<FieldTypeOperator> IReferencedBy<FieldTypeOperator>.MyTs { get => FieldTypeOperators; }
    }

}

