using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.API.Controllers
{
    public class PersonController : Controller
    {
        private readonly IGenericRepository<Person> person;

        public PersonController(IGenericRepository<Person> _person)
        {
            person=_person;
        }

        // GET: Person
        [HttpGet, ActionName("Index")]
        public IActionResult Index()
        {
            IEnumerable<Person> people = person.GetAll();
            return View(people);
        }

        // GET: Person/Details/5
        public IActionResult Details(int id)
        {
            Person _person = person.GetById(id);

            if (_person == null)
            {
                return NotFound();
            }

            else return View(_person);
        }

        [HttpGet]
        // GET: Person/Create
        // méthode get : create | modifiée
        public IActionResult Create()
        {

            return View("Create");
        }

        // POST: Person/Create
        //méthode modifiée
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdPerson,FirstName,LastName,Job,Role")] Person per)
        {
            if (ModelState.IsValid)
            {
                person.Insert(per);
                person.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet, ActionName("Edit")]
        // GET: Person/Edit/5
        //METHODE GET : edit person (non modifiée)
        public IActionResult Edit(int id)
        {
            Person _person = person.GetById(id);

            if (_person == null)
            {
                return NotFound();
            }

            else return View(_person);
        }

        // POST: Person/Edit/5
        //méthode modifiée
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdPerson,FirstName,LastName,Job,Role")] Person per)
        {
            if (id != per.IdPerson)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    person.Update(per);
                    person.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(per.IdPerson))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet, ActionName("Delete")]
        // GET: Person/Delete/5
        // méthode modifiée :
        public IActionResult Delete(int id)
        {
            Person _person = person.GetById(id);
            if (_person == null)
            {
                return BadRequest("Person is not found");
            }
            person.Delete(_person.IdPerson);
            person.Save();
            return RedirectToAction(nameof(Index));
        }

        //// POST: Person/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var person = await _context.Person.FindAsync(id);
        //    _context.Person.Remove(person);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        // POST: Person/Delete/5
        //méthode modifiée
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Person _person = person.GetById(id);

            if (_person == null)
            {
                return NotFound();
            }
            else
            {
                person.Delete(_person.IdPerson);
                person.Save();
                return RedirectToAction(nameof(Index));
            }
        }

        //méthode modifiée :
        private bool PersonExists(int _id)
        {
            IEnumerable<Person> people = person.GetAll();

            bool test = false;
            foreach (Person item in people)
            {
                if (item.IdPerson == _id)
                { test = true; }

            }
            return test;
        }
    }
}
