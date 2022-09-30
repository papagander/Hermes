using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDataCoreService
    {
        // Field Type
        int Create(FieldType ft);
        int Create(Operator op);
        int Create(Conjoiner cjr);
        int Create(FieldType fieldType, Operator op);
        FieldType GetFieldType(int id);
        Operator GetOperator(int id);
        Conjoiner GetConjoiner(int id);
        FieldTypeOperator? GetFieldTypeOperator(FieldType ft, Operator op);
        IEnumerable<FieldType> GetAllFieldTypes();
        IEnumerable<Operator> GetAllOperators();
        IEnumerable<Conjoiner> GetAllConjoiners();
        IEnumerable<FieldTypeOperator> GetAllFtos();
        IEnumerable<Operator> GetOperators(FieldType ft);
        IEnumerable<FieldType> GetFieldTypes(Operator ent);

        int Remove(FieldType ft);
        int Remove(Operator op);
        int Remove(Conjoiner cjr);
        int Remove(FieldType ft, Operator op);

    }
}
