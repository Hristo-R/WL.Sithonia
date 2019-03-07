namespace WL.Sithonia.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WL.Sithonia.Data;
    using WL.Sithonia.Models;
    using WL.Sithonia.Web.Models.BindingModels;
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
            customers.Insert(0, new CustomerViewModel());

            return this.View(customers);
        }

        [HttpPost]
        public JsonResult InsertCustomer(CustomerInsertModel customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                Country = customer.Country
            };

            this.db.Customers.Add(newCustomer);
            this.db.SaveChanges();

            return Json(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            var updatedCustomer = this.db.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            updatedCustomer.Name = customer.Name;
            updatedCustomer.Country = customer.Country;
            this.db.SaveChanges();

            return new EmptyResult();
        }
    }
}
