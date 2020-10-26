using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaFiKaWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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
        //public ActionResult Admin()
        //{
        //    string apiUri = Url.HttpRouteUrl("Default", new { controller = "admin", });
        //    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();
        //    return View();
        //}
    }
}