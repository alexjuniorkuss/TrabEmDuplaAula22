using MvcAlexRodolfo.Models;
using MvcAlexRodolfo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAlexRodolfo.Controllers
{
    public abstract class BaseController<M, R> : Controller where M : BaseModel where R : BaseDAO<M>
    {
        R repository;
        //construtor
        public BaseController(R repo)
        {
            this.repository = repo;
        }
        //actions
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(M model)
        {
            repository.Create(model);
            ModelState.Clear();
            return View();
        }

        public ActionResult Read()
        {
            return View(repository.Read());
        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            M model = repository.Read(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(M model)
        {
            repository.Update(model);
            return RedirectToAction("Read");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repository.Read(id));
        }
        [HttpPost]
        public ActionResult Delete(M model)
        {
            repository.Delete(repository.Read(model.Id));
            return RedirectToAction("Read");
        }

        public ActionResult Details(int Id)
        {
            M model = repository.Read(Id);
            return View(model);
        }
    }
}