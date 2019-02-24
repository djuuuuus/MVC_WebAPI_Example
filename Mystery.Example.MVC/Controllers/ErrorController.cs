using System.Web.Mvc;

namespace Mystery.Example.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}