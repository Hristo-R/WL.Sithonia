namespace WL.Sithonia.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WL.Sithonia.Data;
    using WL.Sithonia.Models;
    using WL.Sithonia.Web.Models.BindingModels;
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

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ProductCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return this.Redirect("/Products/Index");
        }
    }
}