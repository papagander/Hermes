// See https://aka.ms/new-console-template for more information

using System.Reflection.PortableExecutable;
using DataAccess.EFCore;

using HermesSeeder;

using Microsoft.EntityFrameworkCore;

using TestConsole.Controllers;
using TestConsole.Controllers.FieldSets;
using TestConsole.DataCore;

class Program 
{
    public static void Main(string[] args)
    {

        ReportContext context = new ReportContextFactory().CreateDbContext(new string[0]);
        Seed(context);
        using (MainMenu mm = new(context))
        {
            mm.Run();
        }
    }
    static void Seed(ReportContext context) 
    {        
        using (var seed = new DataCoreSeeder(context))
        {
            //seed.Seed();
        }
        using (var seed = new FieldSetSeeder(context))
        {
            //seed.Seed();
        }
        using (var seed = new QuerySeeder(context)) {
        
            //seed.Seed();
        }
    }
}