using DataAccess.EFCore;
using DataAccess.EFCore.Interfaces.UnitsOfWork;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataCore;

using Domain.Interfaces.Models;

using Services;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;

namespace TestConsole.Controllers
{
    public abstract class GenericEntityController<T> :
        GenericController
        , IEntityController<T> where T : class, IIndexed
    {
        protected GenericEntityController(ReportContext context) : base(context)
        {
            Acts.Add(new Function("add", Add));
            Acts.Add(new Function("show", Show));
        }

        protected abstract string EntityType { get; }
        protected override void MenuPrompt()
        {
            Console.Write($"{EntityType}.");
        }
        public abstract void Add();
        public abstract void Show();
        protected string? NamePrompt(string entityType)
        {
            Console.WriteLine($"Please provide {entityType} name");
            string? name = Console.ReadLine().Trim();
            if (name is null | name == "")
            {
                return null;
            }
            return name;
        }
    }
}
