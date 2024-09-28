using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository repository=new EducationRepository();
        public ActionResult Index()
        {
            var values=repository.List();
            return View(values);
        }
    }
}