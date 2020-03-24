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
        private readonly CodingBlastDdContext _context;
        private IGenericRepository<Ticket> ticket;

        public TicketController(IGenericRepository<Ticket> _ticket)
        {
            ticket=_ticket;
        }

        // GET: Ticket 
        // méthode modifiée :
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            return Ok(tickets);
        }
        [HttpGet]
        // GET: Ticket/Details/5
        // méthode modifiée :
        public IActionResult Details(int id)
        {
            Ticket _ticket = ticket.GetById(id);

            if (_ticket == null)
            {
                return NotFound("The ticket couldn't be found.");
            }

            else return Ok(_ticket);
        }

        

        [HttpGet]
        // GET: Ticket/Create
        public IActionResult Create()
        {
            ViewData["IdWriter"] = new SelectList(_context.Person, "IdPerson", "Discriminator");
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTicket,NameTicket,State,IdWriter")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdWriter"] = new SelectList(_context.Person, "IdPerson", "Discriminator", ticket.IdWriter);
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["IdWriter"] = new SelectList(_context.Person, "IdPerson", "Discriminator", ticket.IdWriter);
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTicket,NameTicket,State,IdWriter")] Ticket ticket)
        {
            if (id != ticket.IdTicket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.IdTicket))
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
            ViewData["IdWriter"] = new SelectList(_context.Person, "IdPerson", "Discriminator", ticket.IdWriter);
            return View(ticket);
        }

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int _id)
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();

            if (_id == 0)
            {
                return false;
            }
            foreach (Ticket item in tickets)
            {
                if(item.IdTicket==_id)
                 return true; 
                  
            }



        }
    }
}
