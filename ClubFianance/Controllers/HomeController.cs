using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubFinance.Controllers
{
    public class HomeController : Controller
    {
        // GET /home/index
        public ActionResult Index()
        {
            return View();
        }

        // GET /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Implementer()
        {
            var implementer = "Anita Wu, Dammy Akinfenwa, Justin Yee, Juyong Jin, Taylor Ladle";
            return Content(implementer);;
        }        
    }
}