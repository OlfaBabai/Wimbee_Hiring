using System;
using Microsoft;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;
namespace Wimbee_Hiring.Persistence
{
    public class AppDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        string connectionString = "@Server=.;database=Wimbee_Hiring;Integrated Security=true";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Caller> Caller { get; set; }
        public DbSet<Recrutor> Recrutor { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Person's Properties
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.IdPerson);
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.LastName).IsRequired();
                entity.Property(p => p.Job).IsRequired();
            });

            // Person's Table configuration
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");
                entity.Property(p => p.IdPerson).HasColumnName("IdPerson");
                entity.Property(p => p.FirstName).HasColumnName("FirstName");
                entity.Property(p => p.LastName).HasColumnName("LastName");
                entity.Property(p => p.Job).HasColumnName("Job");
                entity.Property(p => p.Tickets).HasColumnName("Tickets");
            });

            // Caller's Properties
            modelBuilder.Entity<Caller>(entity =>
            {
                entity.HasKey(p => p.IdPerson);
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.LastName).IsRequired();
                entity.Property(p => p.Job).IsRequired();
            });

            // Caller's Table configuration
            modelBuilder.Entity<Caller>(entity =>
            {
                entity.ToTable("Caller");
                entity.Property(p => p.IdPerson).HasColumnName("IdCaller");
                entity.Property(p => p.FirstName).HasColumnName("FirstName");
                entity.Property(p => p.LastName).HasColumnName("LastName");
                entity.Property(p => p.Job).HasColumnName("Job");
                entity.Property(p => p.Tickets).HasColumnName("Tickets");
            });

            // Recrutor's Properties
            modelBuilder.Entity<Recrutor>(entity =>
            {
                entity.HasKey(p => p.IdPerson);
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.LastName).IsRequired();
                entity.Property(p => p.Job).IsRequired();
            });

            // Recrutor's Table configuration
            modelBuilder.Entity<Recrutor>(entity =>
            {
                entity.ToTable("Recrutor");
                entity.Property(p => p.IdPerson).HasColumnName("IdRecrutor");
                entity.Property(p => p.FirstName).HasColumnName("FirstName");
                entity.Property(p => p.LastName).HasColumnName("LastName");
                entity.Property(p => p.Job).HasColumnName("Job");
                entity.Property(p => p.Tickets).HasColumnName("Tickets");
            });

            // Ticket's Properties
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");
                entity.HasKey(t => t.IdTicket);
                entity.Property(t => t.NameTicket).IsRequired();
                entity.Property(t => t.State).IsRequired();
                entity.HasOne(t => t.Writer).WithMany(p => p.Tickets)
                .HasForeignKey(t => t.Writer);
            });

            // Ticket's table configuration
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(t => t.IdTicket).HasColumnName("IdTicket");
                entity.Property(t => t.NameTicket).HasColumnName("NameTicket");
                entity.Property(t => t.State).HasColumnName("State");
                entity.Property(t => t.Writer).HasColumnName("Writer");
            });
        }


    }
}

