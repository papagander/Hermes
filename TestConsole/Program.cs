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
        var optionsBuilder = ReportContext.SqlLiteOptionsBuilder();

        ReportContext context = new ReportContext(optionsBuilder.Options);
        using (DataCoreController dc = new DataCoreController(context))
        {
            dc.Run();
        }
        /*
        using (FieldSetController controller = new(context))
        {
            controller.Run();
        }
        */

        using (MainMenu mm = new(context))
        {
            mm.Run();
        }
    }
}