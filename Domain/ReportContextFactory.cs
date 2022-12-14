using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReportContextFactory : IDesignTimeDbContextFactory<ReportContext>
    {
        public ReportContext CreateDbContext(string[] args)
        {
            //SetupSqlite();
            var optionsBuilder = ReportContext.SqlServerOptionsBuilder();

            return new ReportContext(optionsBuilder.Options);
        }
        void SetupSqlite()
        {
            if (!Directory.Exists(ReportContext.DirPath)) Directory.CreateDirectory(ReportContext.DirPath);
            if (!File.Exists(ReportContext.SqliteDbPath)) File.Create(ReportContext.SqliteDbPath);
        }
    }
}
