namespace WL.Sithonia.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WL.Sithonia.Data;
    using WL.Sithonia.Web.Models.ViewModels;

    public class SithoniaController : Controller
    {
        private readonly SithoniaDbContext db;

        public SithoniaController(SithoniaDbContext db)
        {
            this.db = db;
        }

        // GET: Sithonia
        public IActionResult Index()
        {
            var customers = this.db.Customers
                .Select(x => new CustomerViewModel
                {
                    CustomerId = x.CustomerId,
                    Name = x.Name,
                    Country = x.Country
                }).ToList();

            //Add a Dummy Row.
            //customers.Insert(0, new CustomerViewModel());

            return this.View(customers);
        }
    }
}
