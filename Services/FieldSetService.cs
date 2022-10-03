using DataAccess.EFCore.Interfaces.UnitsOfWork.FieldSets;
using DataAccess.EFCore.UnitOfWork.FieldSets;

using Domain.Models.DataCore;
using Domain.Models.FieldSets;

using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FieldSetService : 
        GenericService
        , IFieldSetService
    {
        private IFieldSetUnitOfWork U;
        public FieldSetService(ReportContext context) : base(context)
        {
            U = new FieldSetUnitOfWork(context);
        }

        public int Complete { get; }

        public int CreateFieldSet(string name, IEnumerable<Field> fields)
        {
            U.Fields.AddRange(fields);
            var fs = new FieldSet { Name = name, Fields = fields.ToList() };
            U.FieldSets.Add(fs);
            return Complete;
        }

        public IEnumerable<FieldSet> GetFieldSets() => U.FieldSets.GetAll();

        public IEnumerable<FieldType> GetFieldTypes()
        {
            throw new NotImplementedException();
        }

        public int Remove(FieldSet fieldSet)
        {
            throw new NotImplementedException();
        }

        public int Remove(string name)
        {
            throw new NotImplementedException();
        }

        public int UpdateFieldSet(FieldSet fieldSet, IEnumerable<Field> fields)
        {
            throw new NotImplementedException();
        }
    }
}
