using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<About> repository=new GenericRepository<About>();
        [HttpGet]
        public ActionResult Index()
        {
            var value= repository.List();
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(List< About> about)
        {
            foreach (var item in about) {
            
            
            var value = repository.Find(x => x.AboutId == 1);
            value.Name = item.Name;
            value.Description = item.Description;
            value.Adress = item.Adress;
            value.Surname = item.Surname;
            value.Phone = item.Phone;
            value.Image = item.Image;
            repository.TUpdate(value);
            
            }
            
            return RedirectToAction("Index");
        }

    }
}