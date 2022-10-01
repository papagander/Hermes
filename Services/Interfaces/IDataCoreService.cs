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
        FieldType GetFieldType(int id);
        Operator GetOperator(int id);
        Conjoiner GetConjoiner(int id);
        IEnumerable<FieldType> GetAllFieldTypes();
        IEnumerable<Operator> GetAllOperators();
        IEnumerable<Conjoiner> GetAllConjoiners();
        IEnumerable<Operator> GetOperators(FieldType ft);
        int SetOperators(FieldType ft, IEnumerable<Operator> op);
        int AddOperators(FieldType ft, IEnumerable<Operator> op);
        int RemoveOperators(FieldType ft, IEnumerable<Operator> op);
        int Remove(FieldType ft);
        int Remove(Operator op);
        int Remove(Conjoiner cjr);
    }
}
