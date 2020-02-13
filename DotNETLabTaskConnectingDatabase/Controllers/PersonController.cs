using DotNETLabTaskConnectingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNETLabTaskConnectingDatabase.Controllers
{
    public class PersonController : Controller
    {
        PersonRepository repo = new PersonRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(Person p)
        {
            return View(repo.GetDetails(p.ID));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repo.GetDetails(id));
        }
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            repo.Update(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            int id = repo.InsertData(p);
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repo.GetDetails(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteUser(int id)
        {
          repo.DeleteData(id);
          return RedirectToAction("Index");
        }
    }
}