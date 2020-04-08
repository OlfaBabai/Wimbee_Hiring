using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wimbee_Hiring.Service.Interfaces;
using Wimbee_Hiring.Models;
using Microsoft.EntityFrameworkCore;

namespace Wimbee_Hiring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> person;

        public PersonController(IGenericRepository<Person> _person)
        {
            person = _person;
        }

        [HttpGet]
        public IEnumerable<Person> Index()
        {
            IEnumerable<Person> people = person.GetAll();
            return people;
        }

        [HttpGet("{id}")]
        public Person Details(int id)
        {
            Person _person = person.GetById(id);
            return _person;
        }

        [HttpPost]
        public IEnumerable<Person> Create([Bind("IdTicket,NameTicket,State,IdWriter")] Person per)
        {
            IEnumerable<Person> people = person.GetAll();
            if (ModelState.IsValid)
            {
                person.Insert(per);
                person.Save();
            }
            return people;
        }

        [HttpPut("{id}")]
        public Person Edit(int id, [Bind("IdTicket,NameTicket,State,IdWriter")] Person per)
        {
            if (id != per.IdPerson)
            {
                Console.WriteLine("Person not found");
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
                    if (!TicketExists(per.IdPerson))
                    {
                        Console.WriteLine("Person not found");
                    }
                    else
                    {
                        throw;
                    }
                }
                return per;
            }
            return per;
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> DeleteConfirmed(int id)
        {
            Person _person = person.GetById(id);
            if (_person != null)
            {
                person.Delete(_person.IdPerson);
                person.Save();
                return RedirectToAction("");
            }
            else return NotFound();
        }

        private bool TicketExists(int _id)
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