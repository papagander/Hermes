using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Domain.Models;
using Domain.Models.DataCore;

namespace DataAccess.EFCore
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }
        public DbSet<Query> Reports { get; set; }

        // Criteria
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Conjunction> Conjuctions { get; set; }
        public DbSet<Conjoiner> Conjoiners { get; set; }
        public DbSet<Criterion> Criteria { get; set; }
        public DbSet<CriterionValue> CriterionValues { get; set; }

        // Queries
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<FieldTypeOperator> FieldTypeOperators{ get; set; }
        public DbSet<QueryField> QueryFields { get; set; }

        // Transmissions
    }
}
