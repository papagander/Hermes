using Domain.Models.FieldSets;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Interfaces.FieldSets
{
    internal interface IFieldSetController : IEntityController<FieldSet>
    {
        public void AddFields();
        public void RemoveFields();
        public void SetFields();

    }
}
