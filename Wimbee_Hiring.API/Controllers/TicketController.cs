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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IGenericRepository<Ticket> ticket;

        public TicketController(IGenericRepository<Ticket> _ticket)
        {
            ticket = _ticket;
        }

        [HttpGet]
        public IEnumerable<Ticket> Index()
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            return tickets;
        }

        [HttpGet("{id}")]
        public Ticket Details(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            return _ticket;
        }

        [HttpPost]
        public IEnumerable<Ticket> Create([Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            if (ModelState.IsValid)
            {
                ticket.Insert(tik);
                ticket.Save();
            }
            return tickets;
        }

        [HttpPut("{id}")]
        public Ticket Edit(int id, [Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
        {
            if (id != tik.IdTicket)
            {
                Console.WriteLine("Ticket not found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticket.Update(tik);
                    ticket.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(tik.IdTicket))
                    {
                        Console.WriteLine("Ticket not found");
                    }
                    else
                    {
                        throw;
                    }
                }
                return tik;
            }
            return tik;
        }

        [HttpDelete("{id}")]
        public ActionResult<Ticket> DeleteConfirmed(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            if (_ticket!=null)
            {
                ticket.Delete(_ticket.IdTicket);
                ticket.Save();
                return RedirectToAction("Index");
            }
            else return NotFound();
        }

        private bool TicketExists(int _id)
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();

            bool test = false;
            foreach (Ticket item in tickets)
            {
                if (item.IdTicket == _id)
                { test = true; }

            }
            return test;
        }

    }
}