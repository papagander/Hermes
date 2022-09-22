using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataCore;
using DataAccess.EFCore.Interfaces.UnitsOfWork.DataSets;
using DataAccess.EFCore.UnitOfWork;
using DataAccess.EFCore.UnitOfWork.DataCore;
using DataAccess.EFCore.UnitOfWork.DataSets;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<IDataCoreUnitOfWork, DataCoreUnitOfWork>();
            builder.Services.AddTransient<IDataSetUnitOfWork, DataSetUnitOfWork>();

            builder.Services.AddTransient<IQueryUnitOfWork, QueryUnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}