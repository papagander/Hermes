﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class ReportContextFactory 
        : IDesignTimeDbContextFactory<ReportContext>
    {
        public ReportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = ReportContext.SqlLiteOptionsBuilder();
            return new ReportContext(optionsBuilder.Options);
        }
    }
}
