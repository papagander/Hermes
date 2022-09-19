using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Domain.Models;

namespace DataAccess.EFCore
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }
        public DbSet<Report> Reports { get; set; }

        // Criteria
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Conjuction> Conjuctions { get; set; }
        public DbSet<Conjoiner> Conjoiners { get; set; }
        public DbSet<Criterion> Criteria { get; set; }
        public DbSet<CriterionValue> CriterionValues { get; set; }

        // Templates
        public DbSet<Template> Templates { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<FieldTypeOperation> FieldTypeOperations{ get; set; }

        // Transmissions
    }
}
