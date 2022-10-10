using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.UnitOfWork;

using Domain.Models.FieldSets;
using Domain.Models.Queries;

using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class QueryService
    : GenericService
    , IQueryService
{
    protected IQueryUnitOfWork U;
    public QueryService(ReportContext _) : base(_)
    {
        U = new QueryUnitOfWork(_);
        UnitOfWork = U;
    }

    public int AddFields(Query query, IEnumerable<Field> fields)
    {
        if (!query.Equals(U.Queries.Get(query.Id))) throw new Exception("Query does not match stored query w same Id.");
        FieldSet fs = query.FieldSet;
        foreach (Field field in fields) if (field.FieldSet != fs) throw new Exception($"{field.Name} is not in {fs.Name}");
        query.Fields.AddRange(fields);
        U.Queries.Add(query);
        return Complete;
    }

    public int CreateQuery(string name, FieldSet fieldSet, IEnumerable<Field> fields)
    {
        foreach (Field field in fields) if (field.FieldSet != fieldSet) return 0;
        var Query = new Query { Name = name, FieldSet = fieldSet, };

    }

    public Query GetQuery(string name)
    {
        throw new NotImplementedException();
    }

    public Query GetQuery(int id)
    {
        throw new NotImplementedException();
    }

    public int RemoveQuery(int id)
    {
        throw new NotImplementedException();
    }

    public int RemoveQuery(string name)
    {
        throw new NotImplementedException();
    }

    public int RemoveQuery(Query query)
    {
        throw new NotImplementedException();
    }

    public int SetFields(Query query, IEnumerable<Field> fields)
    {
        throw new NotImplementedException();
    }
}