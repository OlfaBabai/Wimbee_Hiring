using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wimbee_Hiring.Models
{
   public class Person
    {
        
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }
}
