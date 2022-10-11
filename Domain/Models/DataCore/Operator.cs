using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class Operator 
        : Named
        , IReferencedBy<FieldType>
        , IReferencedBy<Parameter>
    {
        // equals, greather than, less than, contains, etc.
        public List<FieldType> FieldTypes { get; set; }
        public List<Parameter> Parameters { get; set; }
        [NotMapped]
        List<FieldType> IReferencedBy<FieldType>.MyTs { get => FieldTypes; set => FieldTypes = value; }
        [NotMapped]
        List<Parameter> IReferencedBy<Parameter>.MyTs { get => Parameters; set => Parameters = value; }
    }

}

