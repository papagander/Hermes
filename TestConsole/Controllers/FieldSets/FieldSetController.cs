using Domain.Models.FieldSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces.FieldSets;

namespace TestConsole.Controllers.FieldSets
{
    public class FieldSetController :
        GenericEntityController<FieldSet>
        , IFieldSetController
    {
        private 
        public FieldSetController(ReportContext context) : base(context)
        {
        }

        protected override string EntityType { get; }

        public override void Add()
        {
            string fsName = NamePrompt("Field Set");
            var field = CreateField()
        }
        public Field CreateField()
        {
            var fts = 
        }

        public void AddFields()
        {
            throw new NotImplementedException();
        }

        public override void HelpPrompt()
        {
            throw new NotImplementedException();
        }

        public void RemoveFields()
        {
            throw new NotImplementedException();
        }

        public override void RemoveRange()
        {
            throw new NotImplementedException();
        }

        public void SetFields()
        {
            throw new NotImplementedException();
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }
    }
}
