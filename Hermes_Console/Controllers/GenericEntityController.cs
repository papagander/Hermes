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
    public abstract class GenericEntityController<T>
        : GenericController
        , IEntityController<T>
        where T
        : class
        , IIndexed
    {
        protected GenericEntityController(ReportContext context) : base(context)
        {
            Actions.Add(new Function("add", Add));
            Actions.Add(new Function("show", ShowAll));
        }

        protected abstract string EntityType { get; }
        public abstract void Add();
        public abstract void ShowAll();
        protected string NamePrompt(string entityType)
        {
            Console.WriteLine($"Please provide {entityType} name");
            Console.ForegroundColor = ConsoleColor.White;
            string? name = Console.ReadLine().Trim();
            if (name is null | name == "")
            {
                throw new Exception(name);
            }
            return name;
        }
    }
}
