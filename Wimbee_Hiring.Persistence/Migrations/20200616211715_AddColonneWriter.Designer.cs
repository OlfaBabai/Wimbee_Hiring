﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wimbee_Hiring.Persistence;

namespace Wimbee_Hiring.Persistence.Migrations
{
    [DbContext(typeof(CodingBlastDdContext))]
    [Migration("20200616211715_AddColonneWriter")]
    partial class AddColonneWriter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wimbee_Hiring.Models.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdPerson")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("IdWriter")
                        .HasColumnType("int");

                    b.Property<string>("NameTicket")
                        .IsRequired()
                        .HasColumnName("NameTicket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTicket");

                    b.HasIndex("IdWriter");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Wimbee_Hiring.Models.Models.Caller", b =>
                {
                    b.HasBaseType("Wimbee_Hiring.Models.Person");

                    b.HasDiscriminator().HasValue("Caller");
                });

            modelBuilder.Entity("Wimbee_Hiring.Models.Models.Recrutor", b =>
                {
                    b.HasBaseType("Wimbee_Hiring.Models.Person");

                    b.HasDiscriminator().HasValue("Recrutor");
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
