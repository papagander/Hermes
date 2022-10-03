using DataAccess.EFCore;

using Domain.Interfaces.Models;

using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;


namespace TestConsole.Controllers;

public abstract class GenericController : IController
{
    //public abstract string ControllerName { get;}
    protected List<Function> Functions = new List<Function>();
    protected readonly ReportContext reportContext;
    public GenericController(ReportContext context)
    {
        reportContext = context;
        Functions.Add(new Function("help", Help));
    }
    public void Pause(int seconds)
    {
        Console.Write(".  ");
        Thread.Sleep(333 * seconds);
        Console.Write(".  ");
        Thread.Sleep(333 * seconds);
        Console.WriteLine(".  ");
        Thread.Sleep(334 * seconds);
    }
    public void Run()
    {
        Console.Clear();
        while (true)
        {
            MenuPrompt();
            string? input = Console.ReadLine();
            if (input is null)
            {
                Console.WriteLine("No command provided.");
                continue;
            }
            input = input.ToLower().Trim();
            foreach (var function in Functions)
            {
                if (function.Name == input)
                {
                    function.Action();
                    break;
                }
            }
            if (input == "quit") break;
        }
    }

    protected abstract void MenuPrompt();
    public void Help()
    {
        Console.Clear();
        HelpPrompt();
        Console.WriteLine();
        Console.WriteLine("Available commands:");
        foreach (var function in Functions)
            Console.WriteLine(function.Name);
        Console.WriteLine("quit");
        Console.WriteLine();
    }
    public abstract void HelpPrompt();
    internal static F? SelectFromList<F>(IEnumerable<F> items) where F : class
    {
        var _ = items.ToList();
        Console.WriteLine("Enter a number to select an item. Press enter to terminate selection.");
        for (int i = 0; i < _.Count; i++)
        {
            F item = _[i];
            Console.WriteLine($"{i}. {item.ToString()}");
        }
        string? input = Console.ReadLine();
        if (input == "") return null;
        int intput;
        if (!int.TryParse(input, out intput))
        {
            Console.WriteLine("Could not parse input.");
            return SelectFromList(_);
        }
        if (intput >= _.Count)
        {
            Console.WriteLine("Input out of range");
            return SelectFromList(_);
        }
        return _[intput];

    }
    protected void ShowList<T>(IEnumerable<T> items) where T : class, IIndexed
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}\t{item.ToString()}");
        }
    }
    protected static List<T> SelectListFromList<T>(IEnumerable<T> source)
        where T : class
    {
        List<T> list = source.ToList();
        List<T> output = new();
        var op = SelectFromList(source);
        while (op is not null)
        {
            list.Remove(op);
            output.Add(op);
            op = SelectFromList(list);
        }
        return output;
    }
    /// <summary>
    /// Spacing: 10, 12
    /// </summary>
    /// <param name=""></param>
    public void Show<T>(IEnumerable<IReferencedBy<T>> tRefs)
        where T : class, IIndexed

    {
        foreach (var tRef in tRefs)
            if (tRef.MyTs.Count != 0)
                foreach (var t in tRef.MyTs)
                    Console.WriteLine(string.Format("{0,10} {1,12}", tRef.ToString(), t.ToString()));
            else Console.WriteLine(String.Format("{0,10} {1,12}", tRef.ToString(), "none"));
    }

}