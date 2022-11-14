using DataAccess.EFCore;

using Services;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Controllers;
using TestConsole.DataCore.Entities;
using TestConsole.Interfaces;

namespace TestConsole.DataCore;
internal class DataCoreController 
    : GenericController
    , IController
{
    protected override string MenuName { get => "Data Core"; }

    public DataCoreController(ReportContext context) : base(context)
    {
        Actions.Add(new("Conjoiners", ConjoinerMenu));
        Actions.Add(new("Operators", OperatorMenu));
        Actions.Add(new("About", About));
    }
    public void ConjoinerMenu()
    {
        ConjoinerController conjoinerController = new(context);
        conjoinerController.Run();
    }
    public void OperatorMenu()
    {
        OperatorController controller = new(context);
        controller.Run();
    }
}
