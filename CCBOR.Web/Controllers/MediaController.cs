using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCBOR.Web.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PhotoGallery()
        {
            return View();
        }
        public ActionResult VideoGallery()
        {
            return View();
        }
        public ActionResult AudioGallery()
        {
            return View();
        }
    }
}