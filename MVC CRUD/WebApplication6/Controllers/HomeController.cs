using Microsoft.AspNetCore.Mvc;
using WebApplication6.DAL;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.slider.ToList());
        }
    }
}
