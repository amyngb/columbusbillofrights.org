using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCBOR.Web.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Resources
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InjectionWells()
        {
            return View();
        }
        public ActionResult EPA()
        {
            return View();
        }
        public ActionResult RadioActiveWasteAlert()
        {
            return View();
        }

    }
}