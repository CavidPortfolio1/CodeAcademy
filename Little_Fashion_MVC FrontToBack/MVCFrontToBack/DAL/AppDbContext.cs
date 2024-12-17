using Microsoft.EntityFrameworkCore;
using MVCFrontToBack.Models;
using System.Collections.Generic;

namespace MVCFrontToBack.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
		public DbSet<Products> Products { get; set; }

	}
    
}
