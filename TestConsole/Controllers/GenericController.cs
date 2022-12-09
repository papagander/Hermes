using DataAccess.EFCore;

using Domain.Interfaces.Models;

using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Interfaces;


namespace TestConsole.Controllers;

public abstract class GenericController
    : IController
    , IDisposable
{
    protected abstract string MenuName { get; }
    protected virtual string AboutBody { get => "Blah Blah Blah"; }
    protected List<Function> Actions = new List<Function>();
    private bool disposedValue;
    protected readonly ReportContext context;
    public GenericController(ReportContext context)
    {
        this.context = context;

        // Add an empty option to offset the others
        Actions.Add(new Function("", Run));
    }
    public void Run()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{MenuName} Interface:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            int FinalActionDex = Actions.Count - 1;
            string numFormat;
            if (FinalActionDex > 9) numFormat = "00";
            else numFormat = "0";
            // Start w one bcuz 0 is an empty and reserved for quit
            for (int i = 1; i < Actions.Count; i++)
            {
                Function? action = Actions[i];
                Console.WriteLine(String.Format("{0,2}. {1,0}", i.ToString(numFormat), action.Name));
            }
            Console.WriteLine(String.Format("{0,2}. {1,0}", numFormat, "Quit"));
            int selection = GetSelection(FinalActionDex);
            Console.WriteLine("\n");
            if (selection == -1) continue;
            if (selection == 0) break;
            Actions[selection].Action();
        }
    }
    protected void About()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"About {MenuName} Interface:");
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(AboutBody);
        Console.WriteLine("______________________________________________________________________________________________________________________");

    }
    public int GetSelection(int max)
    {
        int secondDigitOfLast = Actions.Count / 10;

        while (true)
        {
            ConsoleKey input = Console.ReadKey().Key;
            int intput0;
            do intput0 = ParseIntegerInput(input);
            while (intput0 == -1);
            if (secondDigitOfLast == 0 || intput0 > secondDigitOfLast) return intput0;
            input = Console.ReadKey().Key;
            int intput1;
            do intput1 = ParseIntegerInput(input);
            while (intput1 == -1);
            int intput = intput0 * 10 + intput1;
            if (intput > max) return -1;
            Actions[intput].Action();

        }
    }
    protected int ParseIntegerInput(ConsoleKey input)
    {
        int output;
        try
        {
            string _ = input.ToString();
            _ = _[1].ToString();
            output = int.Parse(_);

        }
        catch (Exception)
        {
            return -1;
        }
        return output;

    }
    internal static T? SelectFromList<T>(IEnumerable<T> items) where T : class
    {
        string symbols = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var _ = items.ToList();
        for (int i = 0; i < _.Count; i++)
        {
            char symbol = symbols[i];
            T item = _[i];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{symbol}.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {item.ToString()}");
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Press a key to select an item. Press escape to terminate selection.");
        Console.ForegroundColor = ConsoleColor.White;
        var input = Console.ReadKey().KeyChar.ToString().ToUpper();
        Console.WriteLine();
        for (int i = 0; i < items.Count(); i++)
            if (input == symbols[i].ToString()) return items.ToList()[i];
        symbols = symbols.ToLower();
        for (int i = 0; i < items.Count(); i++)
            if (input == symbols[i].ToString()) return items.ToList()[i];
        return null;
    }
    protected IEnumerable<T>? CreateList<T>(Func<T?> Create)
        where T : class, IIndexed
    {
        var output = new List<T>();
        var t = Create();
        while (t is not null)
        {
            output.Add(t);
            ShowList(output);
            t = Create();
        }
        if (output.Count == 0) return null;
        else return output;
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
        List<T> sourceTs = source.ToList();
        List<T> output = new();
        var t = SelectFromList(source);
        while (t is not null & sourceTs.Count != 1)
        {
            sourceTs.Remove(t);
            output.Add(t);
            Console.Clear();
            ShowSelection(output);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Remaining:");
            t = SelectFromList(sourceTs);
        }
        return output;
        void ShowSelection(IEnumerable<T> selection)
        {
            if (selection.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Current Selection:");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var item in selection)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
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
    public void Pause(int seconds)
    {
        Console.Write(".  ");
        Thread.Sleep(333 * seconds);
        Console.Write(".  ");
        Thread.Sleep(333 * seconds);
        Console.WriteLine(".  ");
        Thread.Sleep(334 * seconds);
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~GenericController()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}