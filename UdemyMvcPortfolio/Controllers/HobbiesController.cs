using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class HobbiesController : Controller
    {
       GenericRepository<Hobbies> repository=new GenericRepository<Hobbies>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        

        [HttpPost]
        public ActionResult Index(List<Hobbies> hobbies)
        {
            foreach (var item in hobbies) 
            { 
            
            var value = repository.Find(x=>x.Id==item.Id);
            value.Descripiton=item.Descripiton;
            repository.TUpdate(value);
            }
            
            return RedirectToAction("Index");
        }

    }
}