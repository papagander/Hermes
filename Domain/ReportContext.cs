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
    public DbSet<FieldType> FieldType { get; set; }
    public DbSet<Operator> Operator { get; set; }

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
// Seed
//  Data Core
        m.Entity<Conjoiner>().HasData(
            new Conjoiner {  Id = 1, Name = "and" }
            , new Conjoiner { Id = 2, Name = "or" }
            );;

        int i = 1;
        var equals = new Operator {  Id = i, Name = "=" };
        i++;
        var nequals = new Operator { Id = i, Name = "!=" };
        i++;
        var lessThan = new Operator { Id = i, Name = "<" };
        i++;
        var greaterThan = new Operator { Id = i, Name = ">" };
        i++;
        var isLastWeek = new Operator { Id = i, Name = "isLastWeek" };

        i = 1;
        var text = new FieldType { Id = i, Name = "text" };
        i++;
        var integer = new FieldType {Id = i,  Name = "integer" };
        i++;
        var date = new FieldType { Id = i, Name = "date" };
        m.Entity<Operator>().HasData(equals, nequals, greaterThan, lessThan, isLastWeek);
        m.Entity<FieldType>().HasData(text, integer, date);

        m.Entity<FieldType>().OwnsMany(e => e.Operators).HasData()    


// Relationships
//  Data Core
        m.Entity<FieldType>()
            .HasMany(e => e.Operators)
            .WithMany(e => e.FieldTypes);

        //  Field Sets

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
        m.Entity<FieldType>()
            .Navigation(e => e.Operators).AutoInclude();

        //  Field Sets
        m.Entity<FieldSet>()
            .Navigation(e => e.Fields).AutoInclude();
        m.Entity<Field>()
            .Navigation(e => e.FieldType).AutoInclude();
    }

    public static DbContextOptionsBuilder<ReportContext> SqlLiteOptionsBuilder()
    {
        return new DbContextOptionsBuilder<ReportContext>().UseSqlite($"Data Source = {ReportContext.SqliteDbPath}");
    }
}