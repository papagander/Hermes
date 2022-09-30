using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class Operator : Named, IReferencedBy<FieldType>
    {
        // equals, greather than, less than, contains, etc.
        public List<FieldType> FieldTypes { get; set; }

        List<FieldType> IReferencedBy<FieldType>.MyTs { get => FieldTypes; }

    }

}

