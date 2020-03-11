using System;
using Microsoft;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;

namespace Wimbee_Hiring.Persistence
{
    public class CodingBlastDdContext : DbContext
    {
        string connectionString = "Server=.;database=Wimbee_Hiring;Integrated Security=true";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public CodingBlastDdContext(DbContextOptions<CodingBlastDdContext> options) : base(options)
        {         }

        public Microsoft.EntityFrameworkCore.DbSet<Person> Person { get; set; }
        public DbSet<Caller> Caller { get; set; }
        public DbSet<Recrutor> Recrutor { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
         
            modelBuilder.Entity<Person>(entity =>
            {
                // Person's Properties

                entity.HasKey(p => p.IdPerson);
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.LastName).IsRequired();
                entity.Property(p => p.Job).IsRequired();

                // Person's Table configuration

                entity.ToTable("Person");
                entity.Property(p => p.IdPerson).HasColumnName("IdPerson");
                entity.Property(p => p.FirstName).HasColumnName("FirstName");
                entity.Property(p => p.LastName).HasColumnName("LastName");
                entity.Property(p => p.Job).HasColumnName("Job");
                entity.Property(p => p.Role).HasColumnName("Role");


            });
                                              
            modelBuilder.Entity<Ticket>(entity =>
            {
                // Ticket's Properties

                entity.ToTable("Ticket");
                entity.HasKey(t => t.IdTicket);
                entity.Property(t => t.NameTicket).IsRequired();
                entity.Property(t => t.State).IsRequired();
                entity.HasOne(t => t.Writer).WithMany(p => p.TicketsWritten).HasForeignKey(t=>t.IdWriter);

                // Ticket's table configuration

                entity.Property(t => t.IdTicket).HasColumnName("IdTicket");
                entity.Property(t => t.NameTicket).HasColumnName("NameTicket");
                entity.Property(t => t.State).HasColumnName("State");
                entity.Property(t => t.IdWriter).HasColumnName("IdWriter");

            });

        }


    }
}

