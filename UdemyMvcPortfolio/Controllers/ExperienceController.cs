using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository experienceRepository =new ExperienceRepository();
        public ActionResult Index()
        {
            var values = experienceRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience() 
        { 
        return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experience experience)
        {
            experienceRepository.TAdd(experience);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            Experience experience = experienceRepository.Find(x => x.ExperienceId == id);
            experienceRepository.TDelete(experience);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id) 
        {
            Experience experience = experienceRepository.Find(x => x.ExperienceId == id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Experience experience)
        {
            var value = experienceRepository.Find(x => x.ExperienceId == experience.ExperienceId);
            value.Subtitle = experience.Subtitle;
            value.Title = experience.Title;
            value.Description = experience.Description;
            value.Date = experience.Date;
            experienceRepository.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}