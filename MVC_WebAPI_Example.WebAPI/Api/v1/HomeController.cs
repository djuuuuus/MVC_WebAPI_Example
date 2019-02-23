using MVC_WebAPI_Example.BLL.Common.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace MVC_WebAPI_Example.WebAPI.Api.v1
{
    public class HomeController : ApiController
    {
        private readonly ITestService service;

        public HomeController(ITestService service)
        {
            this.service = service;
        }

        // GET: api//v1/Home
        public IEnumerable<string> Get() => service.Method1();
    }
}
