using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;


namespace UdemyMvcPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db=new DbCVEntities();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var values=db.SocialMedia.ToList();
            return PartialView(values);
        }

        public PartialViewResult Experience()
        {
            var values=db.Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skills()
        {
            var values = db.Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Hobbies()
        {
            var values = db.Hobbies.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificates()
        {
            var values = db.Certificates.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }

    }
}