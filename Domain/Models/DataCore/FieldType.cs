using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.DataCore
{
    public class FieldType 
        : Named
        , IReferencedBy<Operator>
    {
        // text, int, date, money?
        public List<Operator> Operators { get; set; }
        [NotNull]
        public SqlDbType Type { get; set; }
        [NotMapped]
        public List<Operator> MyTs { get => Operators; set => Operators = value; }
    }

}

