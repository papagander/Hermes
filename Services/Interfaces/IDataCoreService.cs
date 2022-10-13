using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDataCoreService
    {
        // Operator
        int AddOperator(string name, string executionString, IEnumerable<SqlDbType> dbTypes, IEnumerable<Parameter> parameters);
        Operator? GetOperator(int id);
        IEnumerable<Operator> GetAllOperators();
        int RemoveOperator(string name);
        int RemoveOperator(int id);
        IEnumerable<Operator> GetOperators(SqlDbType dbType);
        int AddFieldTypes(int operatorId, IEnumerable<SqlDbType> dbTypes);

        int AddConjoiner(string name);
        Conjoiner? GetConjoiner(int id);
        Conjoiner? GetConjoiner(string name);
        IEnumerable<Conjoiner> GetAllConjoiners();
        int RemoveConjoiner(Conjoiner cjr);
        //int RemoveFieldTypes(string operatorName, IEnumerable<DbType> dbTypes);
        //int SetFieldTypes(string operatorName, IEnumerable<DbType> dbTypes);
    }
}
