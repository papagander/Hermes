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

namespace TestConsole
{
    public abstract class GenericEntityController<T> :
        GenericController
        , IEntityController<T> where T : class, IIndexed
    {
        protected GenericEntityController(ReportContext context) : base(context)
        {
            Functions.Add(new Function("add", Add));
            Functions.Add(new Function("get", ShowAll));
            Functions.Add(new Function("remove", Remove));
        }

        protected abstract string EntityType { get; }
        protected override void MenuPrompt()
        {
            Console.Write($"{EntityType}.");
        }
        public abstract void Add();
        public abstract void ShowAll();
        public abstract void Remove();
        protected string NamePrompt(string entityType)
        {
            Console.WriteLine($"Please provide {entityType} name");
            string? name = Console.ReadLine();
            if (name is null)
            {
                Console.WriteLine("No name provided.");
                return NamePrompt(entityType);
            }
            return name;
        }
    }
}
