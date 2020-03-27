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
        private IGenericRepository<Ticket> ticket;

        public TicketController(IGenericRepository<Ticket> _ticket)
        {
            ticket = _ticket;
        }
        
        // GET: Ticket 
        // méthode modifiée :
        [HttpGet, ActionName("Index")]
        public IActionResult Index()
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            return View(tickets);
        }
        
        [HttpGet, ActionName("Details")]

        // GET: Ticket/Details/5
        // méthode modifiée :
        public IActionResult Details(int id)
        {
            Ticket _ticket = ticket.GetById(id);

            if (_ticket == null)
            {
                return NotFound();
            }

            else return View(_ticket);
        }

        

        [HttpGet]
        // GET: Ticket/Create
        // méthode get : create | modifiée
        public IActionResult Create()
        {

            return RedirectToAction(nameof(Index));
        }

        // POST: Ticket/Create
        //méthode modifiée
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
        {
            if (ModelState.IsValid)
            {
                ticket.Insert(tik);
                ticket.Save();
                return RedirectToAction(nameof(Index));
            }
           return View(ticket);

        }

        [HttpGet, ActionName("Edit")]
        // GET: Ticket/Edit/5
        //METHODE GET : edit ticket (non modifiée)
        public IActionResult Edit(int id)
        {
            Ticket _ticket = ticket.GetById(id);

            if (_ticket == null)
            {
                return NotFound();
            }

            else return View(_ticket);
        }

        // POST: Ticket/Edit/5
        //méthode modifiée
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
        {
            if (id != tik.IdTicket)
            {
                return NotFound();
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }
        [HttpGet, ActionName("Delete")]
        // GET: Ticket/Delete/5
        // méthode modifiée :
        public IActionResult Delete(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            if (_ticket == null)
            {
                return BadRequest("Ticket is not found");
            }
            ticket.Delete(_ticket.IdTicket);
            ticket.Save();
            return NoContent();
        }

        // méthode par défaut :
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ticket = await _context.Ticket
        //        .Include(t => t.Writer)
        //        .FirstOrDefaultAsync(m => m.IdTicket == id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ticket);
        //}


        
        // POST: Ticket/Delete/5
        //méthode modifiée
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            
            if (_ticket == null) 
            { 
                return NotFound();
            }
            else
            {
                ticket.Delete(_ticket.IdTicket);
                ticket.Save();
                return RedirectToAction(nameof(Index));
            }
        }


        //méthode modifiée :
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
