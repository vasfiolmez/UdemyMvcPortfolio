using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class SkillsController : Controller
    {
        GenericRepository<Skills> skillsRepository = new GenericRepository<Skills>();
       
        public ActionResult Index()
        {
            var values = skillsRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skills skills)
        {
            skillsRepository.TAdd(skills);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var value = skillsRepository.Find(x => x.SkillId == id);
            skillsRepository.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            Skills skills = skillsRepository.Find(x => x.SkillId == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skills skills)
        {
            var value = skillsRepository.Find(x => x.SkillId == skills.SkillId);
            value.Skill = skills.Skill;
            value.Rate = skills.Rate;
            
            skillsRepository.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}