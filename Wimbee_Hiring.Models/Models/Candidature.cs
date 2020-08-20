using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wimbee_Hiring.Models.Models
{
    public class Candidature
    {
        public int IdCandidature { get; set; }
        public string PrenomCandidat { get; set; }
        public string NomCandidat { get; set; }
        public string EtatCandidature { get; set; }
        public /*IFormFile*/ string CV { get; set; }
        public Ticket Demande { get; set; }
        public int IdTicket { get; set; }
    }

    
}
