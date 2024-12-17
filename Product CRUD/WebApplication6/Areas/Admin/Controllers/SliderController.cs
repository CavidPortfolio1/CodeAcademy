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

        [HttpGet]
        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var sliders = _db.slider.FirstOrDefault(p => p.Id == Id);
            //sliders = _db.slider.Find(Id);
            return View(sliders);
        }

        [HttpPost]
        public IActionResult Update (int? id, Slider slider )
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(slider);

            }
            var oldSlider = _db.slider.FirstOrDefault(p => p.Id == id);
            if (oldSlider == null)
            {
                return NotFound();
            }
            oldSlider.Id = (int)id;
            oldSlider.Name = slider.Name;
            oldSlider.ImgUrl = slider.ImgUrl;
            oldSlider.Description = slider.Description;
            oldSlider.Discount = slider.Discount;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
           var delId = _db.slider.Find(id);
            if (delId != null)
            {
                _db.slider.Remove(delId);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();

        }
    }
}
