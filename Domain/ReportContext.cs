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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Domain.Interfaces.Models;

namespace Domain;

public class ReportContext
    : DbContext
{
    const string SQLITEDBNAME = "ReportDb.db";
    public static string SqliteDbPath { get => Path.Combine(DirPath, SQLITEDBNAME); }
    public static string DirPath =>
    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Hermes");
    public ReportContext(DbContextOptions<ReportContext> options) : base(options)
    {

    }
    // Core
    public DbSet<Conjoiner> Conjoiner { get; set; }
    public DbSet<Operator> Operator { get; set; }
    public DbSet<OperatorFieldType> OperatorFieldType { get; set; }
    public DbSet<Parameter> Parameter { get; set; }

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
        m.Entity<Query>()
            .Property(x => x.Name)
            .HasColumnType("varchar(50)");
        m.Entity<FieldSet>()
            .Property(x => x.Name)
            .HasColumnType("varchar(50)");
        m.Entity<Field>()
            .Property(x => x.Name)
            .HasColumnType("varchar(50)");
        m.Entity<Conjoiner>()
            .Property(x => x.Name)
            .HasColumnType("varchar(50)");
        m.Entity<Query>()
            .Property(x => x.Name)
            .HasColumnType("varchar(50)");

        m.Entity<Operator>().HasIndex(e => e.Id);
        m.Entity<OperatorFieldType>().HasIndex(e => e.Id);
        m.Entity<Parameter>().HasIndex(e => e.Id);
        m.Entity<Conjoiner>().HasIndex(e => e.Id);

        m.Entity<FieldSet>().HasIndex(e => e.Id);
        m.Entity<Field>().HasIndex(e => e.Id);

        m.Entity<Query>().HasIndex(e => e.Id);
        m.Entity<Operation>().HasIndex(e => e.Id);
        m.Entity<OperationParameter>().HasIndex(e => e.Id);
        m.Entity<Conjunction>().HasIndex(e => e.Id);

        m.Entity<Operator>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<OperatorFieldType>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<Parameter>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<Conjoiner>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);

        m.Entity<FieldSet>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<Field>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);

        m.Entity<Query>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<Operation>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<OperationParameter>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);
        m.Entity<Conjunction>()
            .Property(x => x.Id)
            .UseIdentityColumn(1, 1);


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

    public static DbContextOptionsBuilder<ReportContext> SqlLiteOptionsBuilder() => new DbContextOptionsBuilder<ReportContext>().UseSqlite($"Data Source = {ReportContext.SqliteDbPath}");
    public static DbContextOptionsBuilder<ReportContext> LocalSqlServerOptionsBuilder() => new DbContextOptionsBuilder<ReportContext>().UseSqlServer("Server=localhost;Database=HermesMessengerDb;Trusted_Connection=true;Encrypt=false;");

    public static DbContextOptionsBuilder<ReportContext> SqlServerAzOptionsBuilder()
    {
        string password = File.ReadAllText("password.txt");
        return new DbContextOptionsBuilder<ReportContext>().UseSqlServer($"Server = tcp:hermes-messenger.database.windows.net, 1433; Initial Catalog = HermesMessengerDb; Persist Security Info = False; User ID = hermes; Password ={password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
    }

}