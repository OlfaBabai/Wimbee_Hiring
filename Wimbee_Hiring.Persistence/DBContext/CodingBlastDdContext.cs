using System;
using Microsoft;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Models.Models;

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
        {        
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Demandeur> Demandeur { get; set; }
        public DbSet<Recruteur> Recruteur { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Candidature> Candidature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(entity =>
            {
                // Person's Properties

                entity.HasKey(p => p.IdPerson);
                entity.Property(p => p.Email).IsRequired();
                entity.Property(p => p.Password).IsRequired();
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.LastName).IsRequired();
                entity.Property(p => p.Job).IsRequired();
                entity.Property(p => p.Departement).IsRequired();
                // Person's Table configuration

                entity.ToTable("Person");
                entity.Property(p => p.IdPerson).HasColumnName("IdPerson");
                entity.Property(p => p.Email).HasColumnName("Email");
                entity.Property(p => p.Password).HasColumnName("Password");
                entity.Property(p => p.FirstName).HasColumnName("FirstName");
                entity.Property(p => p.LastName).HasColumnName("LastName");
                entity.Property(p => p.Job).HasColumnName("Job");
                entity.Property(p => p.Departement).HasColumnName("Departement");

                entity.HasDiscriminator<String>("Role")
                .HasValue<Demandeur>("Demandeur")
                .HasValue<Recruteur>("Recruteur");

            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                // Ticket's Properties

                entity.ToTable("Ticket");
                entity.HasKey(t => t.IdTicket);
                entity.Property(t => t.NameTicket).IsRequired();
                entity.Property(t => t.StateTraitement).IsRequired();
                entity.Property(t => t.StateValidation).IsRequired();
                entity.Property(t => t.Poste).IsRequired();
                entity.Property(t => t.DepartementTicket).IsRequired();
                entity.Property(t => t.CompetenceTechnique).IsRequired();
                entity.Property(t => t.CompetenceFonctionnelle).IsRequired();
                entity.Property(t => t.SoftSkills).IsRequired();
                entity.Property(t => t.Certification).IsRequired();
                entity.Property(t => t.NombreAnnee).IsRequired();
                entity.Property(t => t.Motif).IsRequired();

                entity.HasOne(t => t.Writer).WithMany(p => p.TicketsWritten).HasForeignKey(t => t.IdWriter).IsRequired();

                // Ticket's table configuration
                entity.Property(t => t.IdTicket).HasColumnName("IdTicket");
                entity.Property(t => t.NameTicket).HasColumnName("NameTicket");
                entity.Property(t => t.StateTraitement).HasColumnName("StateTraitement");
                entity.Property(t => t.StateValidation).HasColumnName("StateValidation");
                entity.Property(t => t.Poste).HasColumnName("Poste");
                entity.Property(t => t.DepartementTicket).HasColumnName("Departement");
                entity.Property(t => t.CompetenceTechnique).HasColumnName("CompetenceTechnique");
                entity.Property(t => t.CompetenceFonctionnelle).HasColumnName("CompetenceFonctionnelle");
                entity.Property(t => t.SoftSkills).HasColumnName("SoftSkills");
                entity.Property(t => t.Certification).HasColumnName("Certification");
                entity.Property(t => t.NombreAnnee).HasColumnName("NombreAnnee");
                entity.Property(t => t.Motif).HasColumnName("Motif");
                // Partie : Projet :
                entity.Property(t => t.NameProjet).HasColumnName("NameProjet");
                entity.Property(t => t.NameClient).HasColumnName("NameClient");
                entity.Property(t => t.DureeInterProjet).HasColumnName("DureeInterProjet");
                entity.Property(t => t.ChargeInterProjet).HasColumnName("ChargeInterProjet");
                entity.Property(t => t.LieuInterProjet).HasColumnName("LieuInterProjet");
                entity.Property(t => t.Confirmation).HasColumnName("Confirmation");
                // Partie : Opportunité :
                entity.Property(t => t.NameOpportunite).HasColumnName("NameOpportunite");
                entity.Property(t => t.NomProspect).HasColumnName("NomProspect");
                entity.Property(t => t.DureeInterOpportunite).HasColumnName("DureeInterOpportunite");
                entity.Property(t => t.ChargeInterOpportunite).HasColumnName("ChargeInterOpportunite");
                entity.Property(t => t.LieuInterOpportunite).HasColumnName("LieuInterOpportunite");
                entity.Property(t => t.Probabilite).HasColumnName("Probabilite");
                // Partie : Stratégique :
                entity.Property(t => t.Description).HasColumnName("Description");
                //Date
                entity.Property(t => t.DateDebutSouhaite).HasColumnName("DateDebutSouhaite");
                entity.Property(t => t.DateDebutPlutard).HasColumnName("DateDebutPlutard");
                entity.Property(t => t.Urgence).HasColumnName("Urgence");
                entity.Property(t => t.Importance).HasColumnName("Importance");
                //Budgétisation
                entity.Property(t => t.SalaireBud).HasColumnName("SalaireBud");
                entity.Property(t => t.PackFinancierAnnuel).HasColumnName("PackFinancierAnnuel");
                entity.Property(t => t.Budgetisation).HasColumnName("Budgetisation");
                //Partie optionnelle :
                entity.Property(t => t.Optionnel).HasColumnName("Optionnel");
            });
            // Candidature's properties 1 ticket--> n candidatures
            modelBuilder.Entity<Candidature>(entity =>
            {
                entity.ToTable("Candidature");
                entity.HasKey(c => c.IdCandidature);
                entity.Property("IdCandidature").HasColumnName("IdCandidature");
                entity.Property("NomCandidat").HasColumnName("NomCandidat").IsRequired();
                entity.Property("PrenomCandidat").HasColumnName("PrenomCandidat").IsRequired();
                entity.Property("EtatCandidature").HasColumnName("EtatCandidat").IsRequired();
                entity.Property("CV").HasColumnName("CV").IsRequired();
                entity.HasOne(c => c.Demande).WithMany(t => t.Candidatures).HasForeignKey(c => c.IdTicket).IsRequired();
            });

        }
    }
}

