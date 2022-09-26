// See https://aka.ms/new-console-template for more information

using DataAccess.EFCore;

using Microsoft.EntityFrameworkCore;

using TestConsole;

class Program 
{
    public static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<ReportContext>()
            .UseInMemoryDatabase("Report DB")
            .Options;

        ReportContext context = new ReportContext(options);
        ConsoleDataCoreController myController = new ConsoleDataCoreController(context);
        myController.CreateConjoiner();

    }
}