using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Repo;

namespace MyLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DeafualtConn")));
            builder.Services.AddScoped<IAddCategory, AddCategory>();
            builder.Services.AddScoped<IAddBook, AddBook>(); 
            builder.Services.AddScoped<IAddMember, AddMember>(); 
            builder.Services.AddScoped<IAddTransatction, AddTransatction>();  
            builder.Services.AddScoped<IAddFine, AddFine>();    
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
                pattern: "{controller=Home}/{action=RegisterMember}/{id?}");

            app.Run();
        }
    }
}
