using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCBOR.Web.Controllers
{
    public class HelpOutController : Controller
    {
        // GET: HelpOut
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Volunteer()
        {
            return View();
        }

        public ActionResult Apparel()
        {
            return View();
        }
    }
}