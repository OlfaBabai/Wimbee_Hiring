using System;
using System.Collections.Generic;
using Wimbee_Hiring.Models.Models;
using Xamarin.Forms;

namespace Wimbee_Hiring.Models
{

    public class Ticket
    {
        public int IdTicket { get; set; }
        public string NameTicket { get; set; }
        public string StateTraitement { get; set; }
        public string StateValidation { get; set; }
        public string Poste { get; set; }
        public string DepartementTicket { get; set; }
        public string CompetenceTechnique { get; set; }
        public string CompetenceFonctionnelle { get; set; }
        public string SoftSkills { get; set; }
        public string Certification { get; set; }
        public float NombreAnnee { get; set; }
        public string Motif { get; set; }
        public string NameProjet { get; set; }
        public string NameClient { get; set; }
        public string DureeInterProjet { get; set; }
        public string ChargeInterProjet { get; set; }
        public string LieuInterProjet { get; set; }
        public string Confirmation { get; set; }
        public string NameOpportunite { get; set; }
        public string NomProspect { get; set; }
        public string DureeInterOpportunite { get; set; }
        public string ChargeInterOpportunite { get; set; }
        public string LieuInterOpportunite { get; set; }
        public string Probabilite { get; set; }
        public string Description { get; set; }
        public string DateDebutSouhaite { get; set; }
        public string DateDebutPlutard { get; set; }
        public string Urgence { get; set; }
        public string Importance { get; set; }
        public double SalaireBud { get; set; }
        public double PackFinancierAnnuel { get; set; }
        public string Budgetisation { get; set; }
        public string Optionnel { get; set; }
        public int IdWriter { get; set; }
        public Person Writer { get; set; }
        public IList<Candidature> Candidatures {get; set;}
    }
}
