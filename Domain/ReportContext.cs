using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Domain.Models;
using Domain.Models.DataCore;
using Domain.Models.DataSets;
using Domain.Models.Queries;

namespace Domain;

public class ReportContext : DbContext
{
    public ReportContext(DbContextOptions<ReportContext> options) : base(options)
    {

    }
    
    // Core
    public DbSet<Conjoiner> Conjoiners { get; set; }
    public DbSet<FieldType> FieldTypes { get; set; }
    public DbSet<Operator> Operators { get; set; }

    // DataSets
    public DbSet<DataSet> DataSets { get; set; }
    public DbSet<Field> Fields { get; set; }

    // Queries
    public DbSet<Query> Queries { get; set; }
    public DbSet<Conjunction> Conjunctions { get; set; }
    public DbSet<Criterion> Criteria { get; set; }
    public DbSet<CriterionValue> CriterionValues { get; set; }
    public DbSet<Statement> Statements { get; set; }
    //public DbSet<FieldTypeOperator> FieldTypeOperators{ get; set; }
    public DbSet<QueryField> QueryFields { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conjunction>()
            .HasOne(cjn => cjn.Statement)
            .WithMany(s => s.Conjunctions);
        modelBuilder.Entity<Statement>()
            .HasOne( st => st.Conjunction)
            .WithMany(s => s.Statements);
        /*
        modelBuilder.Entity<Operator>()
            .HasMany(op => op.FieldTypeOperators)
            .WithOne(fto => fto.Operator);
        modelBuilder.Entity<FieldType>()
            .HasMany(ft => ft.FieldTypeOperators)
            .WithOne(fto => fto.FieldType);
        */
        modelBuilder.Entity<FieldType>()
            .Navigation(e => e.FieldTypeOperators).AutoInclude();
        /*
        modelBuilder.Entity<FieldTypeOperator>()
            .Navigation(e => e.Operator).AutoInclude();
        modelBuilder.Entity<FieldTypeOperator>().HasAlternateKey(e => new { e.OperatorId, e.FieldTypeId }).HasName("FieldTypeOperator");
        */



    }
    /*
    DbContextOptions options = new DbContextOptionsBuilder<ReportContext>()
        .UseSqlite(@"C:\Users\TimDolin\Desktop\TestDb.sqlite")
        .Options;
    */
}
