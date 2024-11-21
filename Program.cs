using Microsoft.EntityFrameworkCore;
using mvcapl1.Models.Data;
using System;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDpContext>(options =>
     options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
         new MySqlServerVersion(new Version(10, 4, 32))
         ));
        
        // Add services to the container.
        builder.Services.AddControllersWithViews();


        var app = builder.Build();
    

       
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}