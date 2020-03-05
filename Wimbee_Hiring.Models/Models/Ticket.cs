using System;
using System.Collections.Generic;


namespace Wimbee_Hiring.Models
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public string NameTicket { get; set; }
        public string State { get; set; }
        public Person Writer { get; set; }
    }
}
