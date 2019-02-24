using System.Web.Mvc;

namespace Mystery.Example.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}