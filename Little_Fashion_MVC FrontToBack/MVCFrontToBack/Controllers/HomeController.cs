using Microsoft.AspNetCore.Mvc;
using MVCFrontToBack.DAL;
using System.Collections.Generic;
using MVCFrontToBack.Models;

namespace MVCFrontToBack.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext dbContext;

		public HomeController(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult Index()
        {
           List<Products> products = new List<Products>();

            Products products2 = new Products()
            {
               
                Name = "Test",
                Description = "Test",
                Price = 65,
                ImgUrl = "evan-mcdougall-qnh1odlqOmk-unsplash.jpeg"
			};
			Products products1= new Products()
			{
				//Id = 2,
				Name = "Tessssst",
				Description = "Testss",
				Price = 15,
				ImgUrl = "jordan-nix-CkCUvwMXAac-unsplash.jpeg"
			};
			Products products3 = new Products()
			{
				//Id=3,
				Name = "Testssss",
				Description = "Testssssssss",
				Price = 25,
				ImgUrl = "anis-m-WnVrO-DvxcE-unsplash.jpeg"
			};
			products.Add(products1);
			products.Add(products2);
			products.Add(products3);

			dbContext.Products.AddRange(products);
			dbContext.SaveChanges();



			return View(products);
        }
    }
}
