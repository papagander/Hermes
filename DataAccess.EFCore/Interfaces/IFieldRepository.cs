using System;
namespace DataAccess.EFCore.Interfaces
{
    public interface IFieldRepository : IGenericRepository<Field>
    {
        IEnumerable<Field> GetFieldsByTemplateId(int templateId);
    }
}

