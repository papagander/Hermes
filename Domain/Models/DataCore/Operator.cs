using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class Operator : Named
    {
        // equals, greather than, less than, contains, etc.
        public List<FieldType> FieldTypes { get; set; }


    }

}

