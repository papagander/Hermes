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
    public ReportContext(DbContextOptions<ReportContext> options) : base(options)
    {

    }

    // Core
    public DbSet<Conjoiner> Conjoiner { get; set; }
    public DbSet<FieldType> FieldType { get; set; }
    public DbSet<Operator> Operator { get; set; }

    // FieldSet
    public DbSet<FieldSet> FieldSet { get; set; }
    public DbSet<Field> Field { get; set; }

    // Query
    public DbSet<Query> Query { get; set; }
    public DbSet<Conjunction> Conjunction { get; set; }
    public DbSet<Criterion> Criterion { get; set; }
    public DbSet<CriterionValue> CriterionValue { get; set; }
    public DbSet<Statement> Statement { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conjunction>()
            .HasOne(cjn => cjn.Statement)
            .WithMany(s => s.Conjunctions);
        modelBuilder.Entity<Statement>()
            .HasOne(st => st.Conjunction)
            .WithMany(s => s.Statements);
        modelBuilder.Entity<FieldType>()
            .HasMany(e => e.Operators)
            .WithMany(e => e.FieldTypes);
        modelBuilder.Entity<FieldType>()
            .Navigation(e => e.Operators).AutoInclude();
    }

}