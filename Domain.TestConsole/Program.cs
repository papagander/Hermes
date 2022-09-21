global using Domain.Models;
global using DataAccess.EFCore.Interfaces;
global using DataAccess.EFCore.Repository;
global using DataAccess.EFCore;
global using Microsoft.EntityFrameworkCore;

namespace test;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("ur mom lmao");
        var options = new DbContextOptionsBuilder<ReportContext>()
            .UseInMemoryDatabase(databaseName: "ReportDatabase")
            .Options;



        Console.WriteLine("ur mom lmao");
    }
}