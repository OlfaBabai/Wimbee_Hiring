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
    public class TicketController : Controller
    {
        private readonly IGenericRepository<Ticket> ticket;

        public TicketController(IGenericRepository<Ticket> _ticket)
        {
            ticket = _ticket;
        }

        public IEnumerable<Ticket> Index()
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            return tickets;
        }

        public Ticket Details(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            return _ticket;
        }

        [HttpPost]
        [Route("[controller]/Create/{IdTicket}/{NameTicket}/{State}/{IdWriter}")]
        [ValidateAntiForgeryToken]
        public IEnumerable<Ticket> Create([Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            if (ModelState.IsValid)
            {
                ticket.Insert(tik);
                ticket.Save();
                return tickets;
            }
            return tickets;
        }

        [HttpGet, ActionName("Edit")]
        // GET: Ticket/Edit/5
        //METHODE GET : edit ticket (non modifiée)
        public ActionResult<Ticket > Edit (int id,string name,string st,int idW)
        {
            Ticket tik = new Ticket();

            tik.IdTicket = id;
            tik.NameTicket = name;
            tik.State = st;
            tik.IdWriter = idW;

            if (!TicketExists(id))
            {
                return NotFound();
            }
            else
            {
                ticket.Update(tik);
                ticket.Save();
                return RedirectToAction("Index");
            }

        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
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

        [HttpGet, ActionName("Delete")]
        public ActionResult<Ticket> Delete(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            if (_ticket == null)
            {
                Console.WriteLine("Ticket not found");
            }
            else
                ticket.Delete(_ticket.IdTicket);
            ticket.Save();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult<Ticket> DeleteConfirmed(int id)
        {            
            Ticket _ticket = ticket.GetById(id);
            if (_ticket == null)
            {
                Console.WriteLine("Ticket not found");
            }
            else
            ticket.Delete(_ticket.IdTicket);
            ticket.Save();
            return RedirectToAction("Index");
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