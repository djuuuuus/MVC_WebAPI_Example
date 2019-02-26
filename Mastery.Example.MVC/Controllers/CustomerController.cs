using System.Web.Mvc;
using Mystery.Example.BLL.Common.Interfaces;
using Mystery.Example.BLL.Common.Models.Customer;

namespace Mastery.Example.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service) => this.service = service;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service?.Dispose();
            }

            base.Dispose(disposing);
        }

        public ActionResult AllCustomers() => View(service.GetCustomers());

        public ActionResult CreateCustomer() => View();

        [HttpPost]
        public ActionResult CreateCustomer(CustomerRequestModel customer) => View(service.CreateCustomers(customer));
    }
}