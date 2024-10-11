using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class UserController : Controller
    {
       GenericRepository<User> repository=new GenericRepository<User>();
        public ActionResult Index()
        {
            var value=repository.List();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult AddUser(User user)
        {
            repository.TAdd(user);
            return RedirectToAction("Index","User");  
        }

        public ActionResult DeleteUser(int id) 
        {
            var value = repository.Find(x=>x.ID==id);
            repository.TDelete(value);

           return RedirectToAction("Index","User");

        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var value=repository.Find(x=>x.ID==id);
           return View(value);
        }
        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            var value = repository.Find(x => x.ID == user.ID);
            value.Username = user.Username;
            value.Password = user.Password;
            repository.TUpdate(value);
            return RedirectToAction("Index","User");

        }

    }
}