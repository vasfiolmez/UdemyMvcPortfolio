using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repository=new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var values=repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia() 
        {          
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            repository.TAdd(socialMedia);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = repository.Find(x => x.ID == id);
            return View(value); 
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value=repository.Find(x => x.ID==socialMedia.ID);
            value.SocialmediaName = socialMedia.SocialmediaName;
            value.İcon = socialMedia.İcon;
            repository.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id) 
        {
            var value = repository.Find(x => x.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index");
        }
        public ActionResult SocialMediaStatusToFalse(int id)
        {
            var value = repository.Find(x => x.ID == id);
            value.Status = false;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
        public ActionResult SocialMediaStatusToTrue(int id)
        {
            var value = repository.Find(x => x.ID == id);
            value.Status = true;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}