using Microsoft.EntityFrameworkCore;

using Migration;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var options = new DbContextOptionsBuilder<ReportContext>()
    .UseSqlite(@"C:\Users\TimDolin\Desktop\TestDb.sqlite")
    .Options;

ReportContext context = new ReportContext(options);