using MVC_WebAPI_Example.BLL.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVC_WebAPI_Example.MVC.Api.v1
{
    public class HomeController : ApiController
    {
        private readonly ITestService service;

        public HomeController(ITestService service) => this.service = service;

        public IEnumerable<string> Get() => service.Method1().ToList();
    }
}
