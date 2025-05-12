using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestConsole.Controllers.FieldSets;
using TestConsole.Controllers.Queries;
using TestConsole.DataCore;
using TestConsole.Interfaces;

namespace TestConsole.Controllers;
public class MainMenu
    : GenericController
    , IController
{
    protected override string MenuName => "Hermes Main";
    public MainMenu(ReportContext context) : base(context)
    {
        Actions.Add(new("DataCore", DataCoreMenu));
        Actions.Add(new("FieldSet", FieldSetsMenu));
        Actions.Add(new("Query", QueriesMenu));
    }
    protected void DataCoreMenu()
    {
        DataCoreController myController = new DataCoreController(context);
        myController.Run();
    }
    protected void FieldSetsMenu()
    {
        FieldSetController controller = new FieldSetController(context);
        controller.Run();
    }
    protected void QueriesMenu()
    {
        var controller = new QueryController(context);
        controller.Run();
    }
}
