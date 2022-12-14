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

public class ReportContext 
    : DbContext
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
    public DbSet<Operation> Operation { get; set; }
    public DbSet<OperationParameter> OperationParameter { get; set; }
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
            .WithOne(e => e.FieldSet)
            .OnDelete(DeleteBehavior.Cascade);
        m.Entity<Query>()
            .HasOne(e => e.FieldSet)
            .WithMany(e => e.Queries)
            .OnDelete(DeleteBehavior.Cascade);


        //  Queries
        m.Entity<Query>()
            .HasMany(e => e.Fields)
            .WithMany(e => e.Queries);
        m.Entity<Query>()
            .HasOne(e => e.FieldSet);

        m.Entity<Field>()
            .HasMany(e => e.Queries)
            .WithMany(e => e.Fields);


        m.Entity<OperationParameter>()
            .HasOne(e => e.Operation)
            .WithMany(e => e.OperationParameters)
            .HasForeignKey(e => e.OperationId)
            .OnDelete(DeleteBehavior.NoAction);

    //  Conjunctions
        m.Entity<Statement>()
            .HasOne(st => st.ParentConjunction)
            .WithMany(s => s.Statements);
        m.Entity<Conjunction>()
            .HasOne(cjn => cjn.Statement)
            .WithMany(s => s.conjunctions);
        m.Entity<Operation>()
            .HasOne(crt => crt.Statement)
            .WithMany(s => s.operations);

// Navigations
    //  Data Core
        m.Entity<Operator>()
            .Navigation(e => e.Parameters).AutoInclude();
        m.Entity<Operator>()
            .Navigation(e => e.OperatorFieldTypes).AutoInclude();

        //  Field Sets
        m.Entity<FieldSet>()
            .Navigation(e => e.Fields).AutoInclude();

        // Queries
        m.Entity<Query>()
            .Navigation(e => e.FieldSet).AutoInclude();
        m.Entity<Query>()
            .Navigation(e => e.Fields).AutoInclude();

        m.Entity<Statement>()
            .Navigation(e => e.operations).AutoInclude();

        m.Entity<Conjunction>()
            .Navigation(e => e.Conjoiner).AutoInclude();
        m.Entity<Conjunction>()
            .Navigation(e => e.Statements).AutoInclude();

        m.Entity<Operation>()
            .Navigation(e => e.Operator).AutoInclude();
        m.Entity<Operation>()
            .Navigation(e => e.Field).AutoInclude();
        m.Entity<Operation>()
            .Navigation(e => e.OperationParameters).AutoInclude();
    }

    public static DbContextOptionsBuilder<ReportContext> SqlLiteOptionsBuilder()
    {
        return new DbContextOptionsBuilder<ReportContext>().UseSqlite($"Data Source = {ReportContext.SqliteDbPath}");
    }
    public static DbContextOptionsBuilder<ReportContext> SqlServerOptionsBuilder()
    {
        return new DbContextOptionsBuilder<ReportContext>().UseSqlServer("Server=localhost;Database=HermesMessengerDb;Trusted_Connection=true;Encrypt=false;");
    }
}