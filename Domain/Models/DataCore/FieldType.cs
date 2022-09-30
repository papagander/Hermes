using Domain.Interfaces.Models;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.DataCore
{
    public class FieldType : Named, IReferencedBy<Operator>, IReferencedBy<FieldTypeOperator>
    {
        // text, int, date, money?
        public List<FieldTypeOperator> FieldTypeOperators { get; set; }
        [NotMapped]
        public List<Operator> Operators {
            get
            {
                List<Operator> operators = new List<Operator>();
                foreach (FieldTypeOperator fieldTypeOperator in FieldTypeOperators) operators.Add(fieldTypeOperator.Operator);
                return operators;
            }
        }
        
        List<Operator> IReferencedBy<Operator>.MyTs => Operators;
        

        List<FieldTypeOperator> IReferencedBy<FieldTypeOperator>.MyTs { get => FieldTypeOperators; }
    }

}

