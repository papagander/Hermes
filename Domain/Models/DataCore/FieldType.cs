using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class FieldType : Named, IReferencedBy<Operator>
    {
        // text, int, date, money?
        public List<Operator> Operators { get; set; }
        List<Operator> IReferencedBy<Operator>.MyTs => Operators;
        

    }

}

