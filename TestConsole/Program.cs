// See https://aka.ms/new-console-template for more information

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
        var optionsBuilder = ReportContext.SqlLiteOptionsBuilder();

        ReportContext context = new ReportContext(optionsBuilder.Options);
        using (var seed = new DataCoreSeeder(context))
        {
            seed.Seed();
        }
        using (var seed = new FieldSetSeeder(context))
        {
            seed.Seed();
        }
        /**/
        using (var seed = new QuerySeeder(context))
        {
            seed.Seed();
        }
        /**/
        using (MainMenu mm = new(context))
        {
            mm.Run();
        }
    }
}