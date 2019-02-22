using System.Web.Mvc;

namespace MVC_WebAPI_Example.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}