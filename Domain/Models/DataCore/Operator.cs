using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.DataCore
{
    public class Operator 
        : Named
        , IReferencedBy<Parameter>
        , IReferencedBy<OperatorFieldType>
    {
        // equals, greather than, less than, contains, etc.
        public List<OperatorFieldType> OperatorFieldTypes { get; set; }
        public List<Parameter> Parameters { get; set; }
        [NotNull]
        public string ExecutionString { get; set; }
        [NotMapped]
        List<OperatorFieldType> IReferencedBy<OperatorFieldType>.MyTs { get => OperatorFieldTypes; set => OperatorFieldTypes = value; }
        [NotMapped]
        List<Parameter> IReferencedBy<Parameter>.MyTs { get => Parameters; set => Parameters = value; }
 
    }

}

