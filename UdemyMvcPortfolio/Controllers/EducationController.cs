using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Education> repository = new GenericRepository<Education>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repository.TAdd(education);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = repository.Find(x => x.EducationId == id);
            repository.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            Education value = repository.Find(x => x.EducationId == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var value=repository.Find(x=>x.EducationId==education.EducationId); 
            value.Subtitle = education.Subtitle;
            value.Title = education.Title;
            value.Date = education.Date;
            value.Subtitle2 = education.Subtitle2;
            value.GNO=education.GNO;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}