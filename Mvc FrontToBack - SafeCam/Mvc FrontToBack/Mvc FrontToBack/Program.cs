using Microsoft.EntityFrameworkCore;
using Mvc_FrontToBack.DAL;

namespace Mvc_FrontToBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }
            );
            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}"
                );

            app.UseStaticFiles();
            app.Run();
        }
    }
}
