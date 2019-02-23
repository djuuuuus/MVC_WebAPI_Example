using MVC_WebAPI_Example.BLL.Common.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace MVC_WebAPI_Example.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService service;

        public HomeController(ITestService service)
        {
            this.service = service;
        }

        public ActionResult Index() => View(service.Method1().ToList());
    }
}