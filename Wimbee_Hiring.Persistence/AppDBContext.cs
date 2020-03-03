using System;
using Microsoft;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;

namespace Wimbee_Hiring.Persistence
{
    public class AppDBContext : DbContext
    {
        
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here


        }
    }
}
