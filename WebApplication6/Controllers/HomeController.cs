using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _db.slider.ToListAsync();
            //List<Product> products = await _db.slider.ToListAsync();

            HomeVm vm = new HomeVm()
            {
                Sliders= sliders
            };
            return View(vm);
        }
    }
}
