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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Wimbee_Hiring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _config;
        private readonly PersonRepository personRepository;
        private readonly IGenericRepository<Person> person;

        public LoginController(IConfiguration configuration, IGenericRepository<Person> p)
        {
            _config = configuration;
            person = p;
        }

        [HttpGet("{email}/{pwd}")]
        public IActionResult Login(string email, string pwd)
        {
            IActionResult response = Unauthorized();
            var user = Authentificate(email, pwd);
            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        [HttpGet]
        private Person Authentificate(string email, string pwd)
        {
            Person user = null;
            IEnumerable<Person> people = person.GetAll();
            foreach (Person per in people)
            {
                if (per.Email == email && per.Password == pwd)
                {
                    user = per;
                }
            }
            return user;
        }

        private string GenerateJSONWebToken(Person userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub,userinfo.FirstName+userinfo.LastName),
            new Claim(JwtRegisteredClaimNames.Email, userinfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodetoken;
        }
        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Bienvenu(e)" + userName;
        }

        //[HttpGet("{email}")]
        //public Person SearchEmail(string email)
        //{
        //    return personRepository.GetByEmail(email);
        //}

        //public bool Verifier(string email, string pwd)
        //{
        //    bool test;
        //    Person p = new Person();
        //    p = personRepository.GetByEmail(email);
        //    if (p != null)
        //    {
        //        if (p.Password == pwd)
        //        {
        //            test=true;
        //        }
        //        else test=false;
        //    }
        //    else test=false;
        //    return test;
        //}

    }
}