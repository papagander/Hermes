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
        int CreateFieldType(string fieldTypeName);
        int DeleteFieldType(string fieldTypeName);
        IEnumerable<FieldType> GetAllFieldTypes();
        IEnumerable<Operator> GetOperatorsByFieldType(int fieldTypeDex);
        IEnumerable<Operator> GetOperatorsByFieldType(string fieldTypeName);

        // Operator
        int CreateOperator(string operatorName);
        int DeleteOperator(string operatorName);
        IEnumerable<Operator> GetAllOperators();
        // Conjoiner
        int CreateConjoiner(string conjoinerName);
        int DeleteConjoiner(string conjoinerName);
        IEnumerable<Conjoiner> GetAllConjoiners();

        // FieldTypeOperator
        int CreateFieldTypeOperator(string fieldTypeName, string operatorName);
        int GetFieldTypeOperator(string fieldTypeName, string operatorName);
        int DeleteFieldTypeOperator(string fieldTypeName, string operatorName);

    }
}
