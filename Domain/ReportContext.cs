using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Domain.Models;
using Domain.Models.DataCore;
using Domain.Models.FieldSets;
using Domain.Models.Queries;

namespace Domain;

public class ReportContext : DbContext
{
    const string SQLITEDBNAME = "ReportDb.db";
    public static string SqliteDbPath { get => Path.Combine(DirPath, SQLITEDBNAME); }
    public static string DirPath
    {
        get => Directory.GetCurrentDirectory();
    }
    public ReportContext(DbContextOptions<ReportContext> options) : base(options)
    {

    }
    // Core
    public DbSet<Conjoiner> Conjoiner { get; set; }
    public DbSet<Operator> Operator { get; set; }
    public DbSet<OperatorFieldType> OperatorFieldTypes{ get; set; }
    public DbSet<Parameter> Parameters{ get; set; }

    // FieldSet
    public DbSet<Models.FieldSets.FieldSet> FieldSet { get; set; }
    public DbSet<Field> Field { get; set; }

    // Query
    public DbSet<Query> Query { get; set; }
    public DbSet<Conjunction> Conjunction { get; set; }
    public DbSet<Criterion> Criterion { get; set; }
    public DbSet<CriterionValue> CriterionValue { get; set; }
    public DbSet<Statement> Statement { get; set; }
    protected override void OnModelCreating(ModelBuilder m)
    {

        // Relationships
        //  Data Core
        m.Entity<Operator>()
            .HasMany(e => e.Parameters)
            .WithOne(e => e.Operator);

        m.Entity<Operator>()
            .HasMany(e => e.OperatorFieldTypes)
            .WithOne(e => e.Operator);
        //  Field Sets
        m.Entity<FieldSet>()
            .HasMany(e => e.Fields)
            .WithOne(e => e.FieldSet);


        //  Queries
        m.Entity<Query>()
            .HasMany(e => e.Fields)
            .WithMany(e => e.Queries);

    //  Conjunctions
        m.Entity<Statement>()
            .HasOne(st => st.Conjunction)
            .WithMany(s => s.Statements);
        m.Entity<Conjunction>()
            .HasOne(cjn => cjn.Statement)
            .WithMany(s => s.Conjunctions);
        m.Entity<Criterion>()
            .HasOne(crt => crt.Statement)
            .WithMany(s => s.Criterions);

// Navigations
    //  Data Core
        m.Entity<Operator>()
            .Navigation(e => e.Parameters).AutoInclude();
        m.Entity<Operator>()
            .Navigation(e => e.OperatorFieldTypes).AutoInclude();

        //  Field Sets
        m.Entity<FieldSet>()
            .Navigation(e => e.Fields).AutoInclude();
    }

    public static DbContextOptionsBuilder<ReportContext> SqlLiteOptionsBuilder()
    {
        return new DbContextOptionsBuilder<ReportContext>().UseSqlite($"Data Source = {ReportContext.SqliteDbPath}");
    }
}