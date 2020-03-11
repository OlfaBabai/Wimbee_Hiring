using Microsoft.AspNetCore.Mvc;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Service;
using Wimbee_Hiring.Service.Interfaces;
using System;

namespace RepositoryUsingEFinMVC.Controllers
{
    public class PersonController : Controller
    {
        private IGenericRepository<Person> repository = null;
        public PersonController()
        {
            this.repository = new GenericRepository<Person>();
        }
        public PersonController(IGenericRepository<Person> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(Person model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Person");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditPerson(int idPerson)
        {
            Person model = repository.GetById(idPerson);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditPerson(Person model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Person");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeletePerson(int idPerson)
        {
            Person model = repository.GetById(idPerson);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int EmployeeID)
        {
            repository.Delete(EmployeeID);
            UnitOfWork().Complete();
            return RedirectToAction("Index", "Person");
        }

        private object UnitOfWork()
        {
            throw new NotImplementedException();
        }
    }
}