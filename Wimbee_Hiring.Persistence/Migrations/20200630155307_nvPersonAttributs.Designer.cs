﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wimbee_Hiring.Persistence;

namespace Wimbee_Hiring.Persistence.Migrations
{
    [DbContext(typeof(CodingBlastDdContext))]
    [Migration("20200630155307_nvPersonAttributs")]
    partial class nvPersonAttributs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wimbee_Hiring.Models.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdPerson")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Departement")
                        .IsRequired()
                        .HasColumnName("Departement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnName("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPerson");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Role").HasValue("Person");
                });

            modelBuilder.Entity("Wimbee_Hiring.Models.Ticket", b =>
                {
                    b.Property<int>("IdTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdTicket")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Budgetisation")
                        .HasColumnName("Budgetisation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Certification")
                        .IsRequired()
                        .HasColumnName("Certification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChargeInterOpportunite")
                        .HasColumnName("ChargeInterOpportunite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChargeInterProjet")
                        .HasColumnName("ChargeInterProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompetenceFonctionnelle")
                        .IsRequired()
                        .HasColumnName("CompetenceFonctionnelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompetenceTechnique")
                        .IsRequired()
                        .HasColumnName("CompetenceTechnique")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Confirmation")
                        .HasColumnName("Confirmation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDebutPlutard")
                        .HasColumnName("DateDebutPlutard")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDebutSouhaite")
                        .HasColumnName("DateDebutSouhaite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Departement")
                        .IsRequired()
                        .HasColumnName("Departement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DureeInterOpportunite")
                        .HasColumnName("DureeInterOpportunite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DureeInterProjet")
                        .HasColumnName("DureeInterProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdWriter")
                        .HasColumnType("int");

                    b.Property<string>("Importance")
                        .HasColumnName("Importance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LieuInterOpportunite")
                        .HasColumnName("LieuInterOpportunite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LieuInterProjet")
                        .HasColumnName("LieuInterProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motif")
                        .IsRequired()
                        .HasColumnName("Motif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameClient")
                        .HasColumnName("NameClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOpportunite")
                        .HasColumnName("NameOpportunite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProjet")
                        .HasColumnName("NameProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameTicket")
                        .IsRequired()
                        .HasColumnName("NameTicket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomProspect")
                        .HasColumnName("NomProspect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("NombreAnnee")
                        .HasColumnName("NombreAnnee")
                        .HasColumnType("real");

                    b.Property<string>("Optionnel")
                        .HasColumnName("Optionnel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PackFinancierAnnuel")
                        .HasColumnName("PackFinancierAnnuel")
                        .HasColumnType("float");

                    b.Property<string>("Poste")
                        .IsRequired()
                        .HasColumnName("Poste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Probabilite")
                        .HasColumnName("Probabilite")
                        .HasColumnType("real");

                    b.Property<double>("SalaireBud")
                        .HasColumnName("SalaireBud")
                        .HasColumnType("float");

                    b.Property<string>("SoftSkills")
                        .IsRequired()
                        .HasColumnName("SoftSkills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateTraitement")
                        .IsRequired()
                        .HasColumnName("StateTraitement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateValidation")
                        .IsRequired()
                        .HasColumnName("StateValidation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urgence")
                        .HasColumnName("Urgence")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTicket");

                    b.HasIndex("IdWriter");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Wimbee_Hiring.Models.Models.Demandeur", b =>
                {
                    b.HasBaseType("Wimbee_Hiring.Models.Person");

                    b.HasDiscriminator().HasValue("Demandeur");
                });

            modelBuilder.Entity("Wimbee_Hiring.Models.Models.Recruteur", b =>
                {
                    b.HasBaseType("Wimbee_Hiring.Models.Person");

                    b.HasDiscriminator().HasValue("Recruteur");
                });

            modelBuilder.Entity("Wimbee_Hiring.Models.Ticket", b =>
                {
                    b.HasOne("Wimbee_Hiring.Models.Person", "Writer")
                        .WithMany("TicketsWritten")
                        .HasForeignKey("IdWriter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
