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
        private GenericRepository<Ticket> ticket;

        public TicketController(GenericRepository<Ticket> _ticket)
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
        // méthode get : create | modifiée
        //public IActionResult Create()
        //{
            
        //    return View();
        //}

        // POST: Ticket/Create
        //méthode modifiée
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
        {
            if (ModelState.IsValid)
            {
                ticket.Insert(tik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return RedirectToAction(nameof(Create));

        }

        // GET: Ticket/Edit/5
        //METHODE GET : edit ticket (non modifiée)
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Ticket tik = ticket.GetById(id);
        //    if (tik == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdWriter"] = new SelectList(_context.Person, "IdPerson", "Discriminator", tik.IdWriter);
        //    return View(tik);
        //}

        // POST: Ticket/Edit/5
        //méthode modifiée
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTicket,NameTicket,State,IdWriter")] Ticket tik)
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
                    await _context.SaveChangesAsync();
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
        //méthode modifiée
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Ticket _ticket = ticket.GetById(id);
            if (_ticket == null) { return NotFound(); }
            else
            {
                ticket.Delete(_ticket.IdTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }


        //méthode modifiée
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
            return false;
        }
    }
}
