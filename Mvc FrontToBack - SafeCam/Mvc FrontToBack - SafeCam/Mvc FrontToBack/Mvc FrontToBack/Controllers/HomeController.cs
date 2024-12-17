using Microsoft.AspNetCore.Mvc;
using Mvc_FrontToBack.DAL;
using Mvc_FrontToBack.Models;

namespace Mvc_FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db;

        public HomeController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Slider> sliders = db.Sliders.ToList();
            return View(sliders);
        }
    }
}
