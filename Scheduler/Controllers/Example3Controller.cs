using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scheduler.Models;
namespace Scheduler.Controllers
{
    public class Example3Controller : Controller
    {
       
            public ActionResult Index()
            {
            Example3Model model = new Example3Model();
                return View(model);
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