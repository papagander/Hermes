using System;
namespace DataAccess.EFCore.Repository.Reports
{
    public class FieldTypeOperatorRepository : GenericRepository<FieldTypeOperator>, IFieldTypeOperatorRepository
    {
        public FieldTypeOperatorRepository(ReportContext reportContext) : base(reportContext) { }
        public void Add(FieldType fieldType, Operator @operator)
        {
            FieldTypeOperator fieldTypeOperator = new FieldTypeOperator { FieldType = fieldType, Operator = @operator };
            _context.FieldTypeOperators.Add(fieldTypeOperator);
        }
        public IEnumerable<Operator> GetOperators(int fieldTypeId)
        {
            IEnumerable<int> operatorIds = (
                from fto in _context.FieldTypeOperators
                where fto.FieldTypeId == fieldTypeId
                select fto.OperatorId
                );
            var Operators = _context.Operators;
            List<Operator> operatorList = new List<Operator>();
            foreach (var operatorId in operatorIds)
                operatorList.Add(Operators.ElementAt(operatorId));
            return operatorList;

        }

    }
}

