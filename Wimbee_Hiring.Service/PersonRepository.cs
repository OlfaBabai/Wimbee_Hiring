using System;
using System.Collections.Generic;
using System.Text;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.Service
{
    public class PersonRepository :  GenericRepository<Person> , IPersonRepository
    {
        private readonly CodingBlastDdContext _context ;
        public PersonRepository(CodingBlastDdContext context) : base(context)
        {
            _context = context;
        }
    }

    public class RecrutorRepository : PersonRepository
    {
        public RecrutorRepository(CodingBlastDdContext context) : base(context)
        {
            
        }

        public void PostResume()
        {
            Console.WriteLine("Dépôt des Cvs");
        }


    }

    public class CallerRepository : PersonRepository
    {
        public CallerRepository(CodingBlastDdContext context) : base(context)
        {

        }
    }
}
