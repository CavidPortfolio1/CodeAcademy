using Microsoft.EntityFrameworkCore;
using Mvc_FrontToBack.Models;

namespace Mvc_FrontToBack.DAL
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Slider> Sliders {  get; set; }
    }
    
}
