using CCBOR.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCBOR.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            dynamic viewModel = new ExpandoObject();
            String metaAuthor = "JMG Software";
            String metaDescription = "Contact The Columbus Community Bill of Rights";
            String metaKeywords = "";
            viewModel.MetaTags = MetaTags.Fill(metaAuthor, metaDescription, metaKeywords);
            viewModel.modelContact = JsonConvert.SerializeObject(ContactForm.GetDefinition());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SendContactForm(ContactForm contactForm)
        {
            Boolean isContactFormSent = false;
            isContactFormSent = ContactForm.Send(contactForm);
            return Json(isContactFormSent);
        }

    }
}