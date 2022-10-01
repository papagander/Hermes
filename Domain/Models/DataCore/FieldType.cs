using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class FieldType : Named, IReferencedBy<Operator>
    {
        // text, int, date, money?
        public List<Operator> Operators { get; set; }
        [NotMapped]
        public List<Operator> MyTs { get => Operators; set => Operators = value; }
    }

}

