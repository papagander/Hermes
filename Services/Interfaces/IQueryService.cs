using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces;
public interface IQueryService
{
    int AddQuery(string name, FieldSet fieldSet, IEnumerable<Field> fields);
    Query GetQuery(string name);
    Query GetQuery(int id);
    int RemoveQuery(int id);
    int RemoveQuery(string name);
    int RemoveQuery(Query query);
    int SetFilter(Query query, Statement statement);
    int SetFields(Query query, IEnumerable<Field> fields);
    int AddFields(Query query, IEnumerable<Field> fields);
    List<Operator> GetOperators(SqlDbType dbType);
}