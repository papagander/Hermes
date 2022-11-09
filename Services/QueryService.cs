using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.Interfaces.Repositories;
using DataAccess.EFCore.UnitOfWork;

using Domain;
using Domain.Models.DataCore;
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
        try
        {
            Verify(query, fields);
            U.Queries.AddChildren(query, fields);
            return Complete;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    public int AddQuery(string name, FieldSet fieldSet, IEnumerable<Field> fields)
    {
        foreach (Field field in fields) if (field.FieldSet != fieldSet) return 0;
        var Query = new Query { Name = name, FieldSet = fieldSet, Fields = fields.ToList() };
        U.Queries.Add(Query);
        return Complete;

    }

    public int AddQuery(string name, FieldSet fieldSet, IEnumerable<Field> fields, Statement topLevelStatement)
    {
        foreach (Field field in fields) if (field.FieldSet != fieldSet) return 0;
        var Query = new Query { Name = name, FieldSet = fieldSet, Fields = fields.ToList(), Statement = topLevelStatement };
        U.Queries.Add(Query);
        return Complete;

    }
    public List<Conjoiner> GetConjoiners() => U.Conjoiners.GetAll().ToList();
    

    public IEnumerable<FieldSet> GetFieldSets()
    {
        return U.FieldSets.GetAll();
    }

    public List<Operator> GetOperators(SqlDbType dbType)
    {
        List<Operator> allOps = U.Operators.GetAll().ToList();
        List<Operator> output = new List<Operator>();
        foreach (Operator op in allOps)
            if (op.DbTypes.Contains(dbType))
                output.Add(op);
        return output;
    }

    public Query? GetQuery(string name)
    {
        return U.Queries.Get(name);
    }

    public Query? GetQuery(int id)
    {
        return U.Queries.Get(id);
    }

    public int RemoveQuery(int id)
    {
        var query = U.Queries.Get(id);
        if (query is null) throw new Exception($"No query with id {id}");
        return RemoveQuery(query);

    }

    public int RemoveQuery(string name)
    {
        var Query = U.Queries.Get(name);
        if (Query is null) throw new Exception($"No query with name {name}");
        return RemoveQuery(Query);
    }

    public int RemoveQuery(Query query)
    {
        if (!query.Equals(U.Queries.Get(query.Id)))
            throw new Exception($"Query {query.Name} with Id {query.Id} does not match {U.Queries.Get(query.Id).Name}");
        U.Queries.Remove(query);
        return Complete;

    }

    public int SetFields(Query query, IEnumerable<Field> fields)
    {
        try
        {
            Verify(query, fields);
            U.Queries.SetChildren(query, fields);
            return Complete;

        }
        catch (Exception)
        {
            return -1;
        }

    }

    public int SetFilter(Query query, Statement statement)
    {
        U.Queries.SetStatement(query, statement);
        return Complete;
    }

    protected bool Verify(Query query)
    {
        if (query is null)
            return false;
        if (!(query.Name == (U.Queries.Get(query.Id).Name)))
            return false;
        if (!(query.FieldSet == (U.Queries.Get(query.Id).FieldSet)))
            return false;
        return true;
    }
    protected bool Verify(Query query, IEnumerable<Field> fields)
    {
        if (!Verify(query)) return false;
        foreach (var field in fields)
            if (field.FieldSet != query.FieldSet)
                throw new Exception($"Field {field.Name} is not on {query.Name}'s fieldset {query.FieldSet.Name}");
        return true;
    }
    

}