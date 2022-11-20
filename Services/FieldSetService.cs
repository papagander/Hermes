using DataAccess.EFCore.Interfaces.UnitsOfWork.FieldSets;
using DataAccess.EFCore.UnitOfWork.FieldSets;

using Domain;
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
    public class FieldSetService
        : GenericService
        , IFieldSetService
    {
        private IFieldSetUnitOfWork U;
        public FieldSetService(ReportContext context) : base(context)
        {
            U = new FieldSetUnitOfWork(context);
            base.UnitOfWork = U;
        }
        public int CreateFieldSet(string name, IEnumerable<Field> fields)
        {
            var fs = new FieldSet { Name = name };
            U.FieldSets.Add(fs);
            var fds = fields.ToList();
            for (int i = 0; i < fds.Count; i++) fds[i].FieldSet = fs;
            U.FieldSets.AddChildren(fs, fds);
            return Complete;
        }

        public IEnumerable<FieldSet> GetFieldSets() => U.FieldSets.GetAll();

        public int Remove(FieldSet fieldSet)
        {
            var fds = fieldSet.Fields;
            U.Fields.RemoveRange(fds);
            U.FieldSets.Remove(fieldSet);
            return Complete;
        }

        public int Remove(string name)
        {
            var fs = U.FieldSets.Get(name);
            var fds = fs.Fields;
            U.Fields.RemoveRange(fds);
            U.FieldSets.Remove(fs);
            return Complete;
        }


        public int AddFields(FieldSet fieldSet, IEnumerable<Field> fields)
        {
            if (U.FieldSets.Get(fieldSet.Id) is null) return -1;
            foreach (var field in fields) field.FieldSet = fieldSet;
            U.Fields.AddRange(fields);
            return Complete;
        }
    }
}
