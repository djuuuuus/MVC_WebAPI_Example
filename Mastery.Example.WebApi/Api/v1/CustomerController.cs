using System.Web.Http;
using Mystery.Example.BLL.Common.Interfaces;
using Mystery.Example.BLL.Common.Models.Customer;

namespace Mastery.Example.Api.v1
{
    public class CustomerController : ApiController
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

        public IHttpActionResult GetCustomers() => Ok(service.GetCustomers());

        [HttpPost] public IHttpActionResult CreateCustomers([FromBody]CustomerRequestModel customer) => Ok(service.CreateCustomers(customer));
    }
}
