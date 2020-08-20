using System;
using System.Collections.Generic;
using System.Text;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Wimbee_Hiring.Service
{
    public class PersonRepository :  GenericRepository<Person> ,  IGenericRepository<Person>
        {
        private readonly CodingBlastDdContext _context ;
        public PersonRepository(CodingBlastDdContext context) : base(context)
        {
            //CodingBlastDdContext ctx = new CodingBlastDdContext(null);
            //_context = ctx;
            _context = context;
        }

        public Person GetByEmail(string email)
        {
            Person person = _context.Person.Where(p => p.Email == email).FirstOrDefault();
            return person;
        }
    }

    public class RecruteuRepository : PersonRepository
    {
        public RecruteuRepository(CodingBlastDdContext context) : base(context)
        {
        
        }
    }

    public class DemandeurRepository : PersonRepository
    {
        public DemandeurRepository(CodingBlastDdContext context) : base(context)
        {

        }
    }

}