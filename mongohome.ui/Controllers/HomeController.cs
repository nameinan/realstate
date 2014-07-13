using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using mongohome.ui.Properties;

namespace mongohome.ui.Controllers
{
    public class HomeController : Controller
    {

         public RealStateContext Context= new RealStateContext();
       
        public JsonResult Index()
        {
            Context.MongoDatabase.GetStats();
            return Json(Context.MongoDatabase.Server.BuildInfo, JsonRequestBehavior.AllowGet);
        }

        public string Test()
        {
            return "This is just a test";
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
    }
}