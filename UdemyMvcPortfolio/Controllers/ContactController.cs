using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Contact> _repository=new GenericRepository<Contact>();    
        public ActionResult Index()
        {
            var values=_repository.List();
            return View(values);
        }
    }
}