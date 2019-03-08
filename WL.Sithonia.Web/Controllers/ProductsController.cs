namespace WL.Sithonia.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WL.Sithonia.Data;
    using WL.Sithonia.Web.Models.ViewModels;

    public class ProductsController : Controller
    {
        private readonly SithoniaDbContext db;

        public ProductsController(SithoniaDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var products = this.db.Products
                .Select(x => new ProductListingViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,                 
                }).ToList();
            
            return this.View(products);
        }

        //[HttpPost]
        //public IActionResult Create(ProductListingViewModel model)
        //{
        //    return
        //}
    }
}