﻿using System.Web.Mvc;

namespace Mastery.Example.MVC.Controllers
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