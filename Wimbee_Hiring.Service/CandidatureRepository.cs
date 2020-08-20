using System;
using System.Collections.Generic;
using System.Text;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Models.Models;
using Wimbee_Hiring.Persistence;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.Service
{
    public class CandidatureRepository : GenericRepository<Candidature>, IGenericRepository<Candidature>
    {
        private readonly CodingBlastDdContext _context;
        public CandidatureRepository(CodingBlastDdContext context) : base(context)
        {
            _context = context;
        }
    }
}
