global using Domain.Models;
using System.Data.Common;

namespace DataAccess.ReportSources;
public static class ReportRetriever
{
    public static DbDataReader GetReport(Template template)
    {
        if (template.Name == "Serial")
        {
            return GetSerialReport( template);
        }
    }

    public static DbDataReader GetSerialReport(Template template)
    {

    }
}

