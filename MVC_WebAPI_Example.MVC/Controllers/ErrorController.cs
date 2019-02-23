using System.Web.Mvc;

namespace MVC_WebAPI_Example.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound() => View();
    }
}