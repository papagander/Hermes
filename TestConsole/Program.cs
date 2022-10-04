// See https://aka.ms/new-console-template for more information

using DataAccess.EFCore;

using Microsoft.EntityFrameworkCore;

using TestConsole.Controllers;
using TestConsole.Controllers.FieldSets;
using TestConsole.DataCore;

class Program 
{
    public static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<ReportContext>()
            .UseSqlite($"Data Source={ReportContext.CONSTRNG}")
            .Options;

        ReportContext context = new ReportContext(options);
        FieldSetController controller = new(context);
        controller.Run();
        
        MainMenu mm = new(context);
        mm.Run();

    }
}