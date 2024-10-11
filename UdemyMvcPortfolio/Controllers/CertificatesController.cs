using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMvcPortfolio.Models.Entity;
using UdemyMvcPortfolio.Repositories;

namespace UdemyMvcPortfolio.Controllers
{
    public class CertificatesController : Controller
    {
        GenericRepository<Certificates> repository = new GenericRepository<Certificates>();
        [Authorize]
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(Certificates certificates)
        {
            repository.TAdd(certificates);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var value = repository.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(Certificates certificates)
        {
            var value = repository.Find(x => x.ID == certificates.ID);
            value.Date = certificates.Date;
            value.Description = certificates.Description;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var value = repository.Find(x => x.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}