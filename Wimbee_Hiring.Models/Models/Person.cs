using System;
using System.Collections.Generic;
using System.Text;

namespace Wimbee_Hiring.Models
{
    public class Person
    {

        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public string Role { get; set; } 
        public ICollection<Ticket> TicketsWritten { set; get; }
    }

    public class Caller : Person
    {
        public Caller()
        {
            Role ="Caller";
        }
    }

    public class Recrutor : Person
    {
        public Recrutor()
        {
            Role = "Recrutor";
        }
    }
}
