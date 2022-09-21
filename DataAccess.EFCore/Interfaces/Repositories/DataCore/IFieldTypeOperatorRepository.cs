using System;
namespace DataAccess.EFCore.Interfaces.Repositories.Reports
{
    public interface IFieldTypeOperatorRepository
    {
        void Add(FieldType fieldType, Operator @operator);
        IEnumerable<Operator> GetOperators(int fieldTypeId);
        IEnumerable<FieldType> GetFieldTypes(int operatorId);
    }
}

