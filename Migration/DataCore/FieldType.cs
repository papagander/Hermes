using Domain.Interfaces.Models;

namespace Migration
{
    public class FieldType : Named, IReferencedBy<Operator>, IReferencedBy<FieldTypeOperator>
    {
        // text, int, date, money?
        public List<FieldTypeOperator> FieldTypeOperators { get; set; }
        public List<Operator> Operators { get; set; }
        
        List<Operator> IReferencedBy<Operator>.MyTs
        {
            get
            {
                List<Operator> operators = new List<Operator>();
                foreach (FieldTypeOperator fieldTypeOperator in FieldTypeOperators) operators.Add(fieldTypeOperator.Operator);
                return operators;
            }
        }

        List<FieldTypeOperator> IReferencedBy<FieldTypeOperator>.MyTs { get => FieldTypeOperators; }
    }

}

