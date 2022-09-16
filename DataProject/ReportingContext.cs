using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace Data;
public class ReportingContext : DbContext
{
    public ReportingContext() : base()
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>()
        .Property(e => e.ReportId)
        .IsRequired();
        
    }
}
