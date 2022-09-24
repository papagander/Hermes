global using DataAccess.EFCore.Interfaces.Repositories;
global using Domain.Models.DataCore;

using System;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore
{
    public interface IFieldTypeOperatorRepository : IReferencesRepository<FieldTypeOperator, FieldType>, IReferencesRepository<FieldTypeOperator, Operator>
    {
        //void Add(FieldType fieldType, Operator @operator);
        //void Remove(FieldType fieldType, Operator @operator);
        //IEnumerable<FieldType> GetFieldTypes(int operatorId);
    }
}

