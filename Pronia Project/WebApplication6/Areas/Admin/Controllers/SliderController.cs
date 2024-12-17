using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Areas.Admin.Controllers
{
    
    public class SliderController : BaseController
    {
        AppDbContext _db;
        public SliderController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _db.slider.ToListAsync();
            return View(sliders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider == null)
            {
                return NotFound();
            }
            _db.slider.Add(slider);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
