global using Domain;

using DataAccess.EFCore.Interfaces.Repositories.DataCore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataCore
{
    public class OperatorRepository : UniquelyNamedRepository<Operator>, IOperatorRepository
    {
        protected ReferencedByRepository<Operator, OperatorFieldType> ft;
        protected ReferencedByRepository<Operator, Parameter> p;
        public OperatorRepository(ReportContext _context) : base(_context)
        {
            ft = new(context);
            p = new(context);
        }

        void IOperatorRepository.Add(string name, string executionString, IEnumerable<DbType> types, IEnumerable<Parameter> parameters)
        {
            throw new NotImplementedException();
            if (!NameIsAvailable(name)) throw new InvalidOperationException("Name is not unique");
            var _types = new List<Type>();
            var op = new Operator { Name = name, ExecutionString = executionString };
        }

        void IReferencedByRepository<Operator, OperatorFieldType>.AddChildren(Operator tRef, IEnumerable<OperatorFieldType> Children) => ft.AddChildren(tRef, Children);

        void IReferencedByRepository<Operator, Parameter>.AddChildren(Operator tRef, IEnumerable<Parameter> Children) => p.AddChildren(tRef, Children);

        IEnumerable<OperatorFieldType> IReferencedByRepository<Operator, OperatorFieldType>.GetChildren(Operator tRef) => ft.GetChildren(tRef);

        IEnumerable<Parameter> IReferencedByRepository<Operator, Parameter>.GetChildren(Operator tRef) => p.GetChildren(tRef);

        void IReferencedByRepository<Operator, OperatorFieldType>.RemoveChildren(Operator tRef, IEnumerable<OperatorFieldType> Children) => ft.RemoveChildren(tRef, Children);

        void IReferencedByRepository<Operator, Parameter>.RemoveChildren(Operator tRef, IEnumerable<Parameter> Children) => p.RemoveChildren(tRef, Children);

        void IReferencedByRepository<Operator, OperatorFieldType>.SetChildren(Operator tRef, IEnumerable<OperatorFieldType> Children) => ft.SetChildren(tRef, Children);

        void IReferencedByRepository<Operator, Parameter>.SetChildren(Operator tRef, IEnumerable<Parameter> Children) => p.SetChildren(tRef, Children);
    }
}
