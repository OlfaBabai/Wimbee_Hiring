﻿using System;
using System.Collections.Generic;
using System.Text;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.Service
{
    public class TicketRepository : GenericRepository<Ticket> , IGenericRepository<Ticket>
    {
        private readonly CodingBlastDdContext _context;
        public TicketRepository(CodingBlastDdContext context) : base(context)
        {
            _context=context;
        }
    }
}