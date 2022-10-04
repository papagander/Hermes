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
    public static string CONSTRNG { get => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\ArcHermes\ReportDb.db"; }
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //[Relationships]
        //  [Data Core]
        modelBuilder.Entity<FieldType>()
            .HasMany(e => e.Operators)
            .WithMany(e => e.FieldTypes);

        //  [Field Sets]

        //  [Queries]
        modelBuilder.Entity<Query>()
            .HasMany(e => e.Fields)
            .WithMany(e => e.Queries);

        //  [Conjunctions]
        modelBuilder.Entity<Statement>()
            .HasOne(st => st.Conjunction)
            .WithMany(s => s.Statements);
        modelBuilder.Entity<Conjunction>()
            .HasOne(cjn => cjn.Statement)
            .WithMany(s => s.Conjunctions);
        modelBuilder.Entity<Criterion>()
            .HasOne(crt => crt.Statement)
            .WithMany(s => s.Criterions);

        //  [Navigations]
        //      [Data Core]
        modelBuilder.Entity<FieldType>()
            .Navigation(e => e.Operators).AutoInclude();

        //      [Field Sets]
        modelBuilder.Entity<FieldSet>()
            .Navigation(e => e.Fields).AutoInclude();
        modelBuilder.Entity<Field>()
            .Navigation(e => e.FieldType).AutoInclude();
    }

}