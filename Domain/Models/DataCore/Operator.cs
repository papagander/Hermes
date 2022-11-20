using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.DataCore;
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
    public List<SqlDbType> DbTypes
    {
        get
        {
            List<SqlDbType> output = new List<SqlDbType>();
            foreach (var fto in OperatorFieldTypes) output.Add(fto.DbType);
            return output;
        }
    }
    [NotMapped]
    List<OperatorFieldType> IReferencedBy<OperatorFieldType>.MyTs { get => OperatorFieldTypes; set => OperatorFieldTypes = value; }
    [NotMapped]
    List<Parameter> IReferencedBy<Parameter>.MyTs { get => Parameters; set => Parameters = value; }


}


