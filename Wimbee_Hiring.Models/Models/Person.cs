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
        public List<Ticket> Tickets { get; set; }
    }

    public class Caller : Person
    {

    }

    public class Recrutor : Person
    {

    }
}
