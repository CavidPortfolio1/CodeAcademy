using Microsoft.EntityFrameworkCore;
using MVCFrontToBack.DAL;

namespace MVCFrontToBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("server=KERIMOVS;database=MvcFronttoback;Trusted_connection=true;encrypt=false");
            });
            var app = builder.Build();

            app.MapControllerRoute
                (
                name: "default",
                pattern: "{controller=home}/{action=index}"
                );



            app.UseStaticFiles();
            app.Run();
        }
    }
}
