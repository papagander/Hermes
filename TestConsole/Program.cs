// See https://aka.ms/new-console-template for more information

using DataAccess.EFCore;

using Microsoft.EntityFrameworkCore;
using TestConsole.DataCore;

class Program 
{
    public static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<ReportContext>()
            .UseInMemoryDatabase("Report DB")
            .Options;

        ReportContext context = new ReportContext(options);
        DataCoreController myController = new DataCoreController(context);
        myController.Run();

    }
}