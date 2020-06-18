using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Service;
using Wimbee_Hiring.Service.Interfaces;
using Wimbee_Hiring.Persistence;

namespace Wimbee_Hiring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PersonRepository personRepository;

        public LoginController()
        {
             personRepository = new PersonRepository (null);
        }

        [HttpPost]
        public Person Verifier(string email, string pwd)
        {
            Person p = new Person();
            p = personRepository.GetByEmail(email);
            //if (p!=null)
            //{ 
            //    if (p.Password == pwd)
            //    { 
            //        return true; 
            //    }
            //    else return false;
            //}
            //else return false;
            return p;
        }
    }
}