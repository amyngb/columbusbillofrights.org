using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCBOR.Web.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComingEvents()
        {
            return View();
        }

        public ActionResult PastEvents()
        {
            return View();
        }
    }
}