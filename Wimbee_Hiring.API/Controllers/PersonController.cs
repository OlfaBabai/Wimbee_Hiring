using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.API.Controllers
{
    public class PersonController : Controller
    {
        private readonly IGenericRepository<Person> person;

        public PersonController(IGenericRepository<Person> _person)
        {
            person = _person;
        }

        public IEnumerable<Person> Index()
        {
            IEnumerable<Person> people = person.GetAll();
            return people;
        }

        public Person Details(int id)
        {
            Person _person = person.GetById(id);
            return _person;
        }

        [HttpGet]
        public IEnumerable<Person> Create([Bind("IdPerson,FirstName,LastName,Job,Role")] Person per)
        {
            IEnumerable<Person> people = person.GetAll();
            if (ModelState.IsValid)
            {
                person.Insert(per);
                person.Save();
                return people;
            }
            return people;
        }

        [HttpGet]
        public Person Edit(int id)
        {
            Person _person = person.GetById(id);

            if (_person == null)
            {
                Console.WriteLine("Person not found");
            }

            return _person;
        }

        [HttpPost, ActionName("Edit")]
        public Person Edit(int id, [Bind("IdPerson,FirstName,LastName,Job,Role")] Person per)
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
                    if (!PersonExists(per.IdPerson))
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