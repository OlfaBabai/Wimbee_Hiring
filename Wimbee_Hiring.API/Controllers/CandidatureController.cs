using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wimbee_Hiring.Models;
using Wimbee_Hiring.Models.Models;
using Wimbee_Hiring.Service.Interfaces;

namespace Wimbee_Hiring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatureController : ControllerBase
    {
        private readonly IGenericRepository<Candidature> candidature;
        private readonly IGenericRepository<Ticket> ticket;
        public static IWebHostEnvironment _environment;
        public CandidatureController(IWebHostEnvironment environment, IGenericRepository<Candidature> _candidature)
        {
            candidature = _candidature;
            _environment = environment;
        }

        //[HttpPost]
        //public string Post(Candidature objFile)
        //{
        //    try
        //    {
        //        if (objFile.CV.Length > 0)
        //        {
        //            if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
        //            {
        //                Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.CV.FileName))
        //            {
        //                objFile.CV.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "\\Upload\\" + objFile.CV.FileName;
        //            }
        //        }
        //        else return "Failed";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
        //}

        [HttpGet]
        public IEnumerable<Candidature> Index()
        {
            IEnumerable<Candidature> candidatures = candidature.GetAll();
            return candidatures;
        }

        [HttpGet("{id}")]
        public Candidature Details(int id)
        {
            Candidature _candidature = candidature.GetById(id);
            return _candidature;
        }

        [HttpPost]
        public IEnumerable<Candidature> Create([Bind("IdCandidature,PrenomCandidat,NomCandidat,EtatCandidature,CV,IdTicket")] Candidature can)
        {
            
            IEnumerable<Candidature> candidatures = candidature.GetAll();
            if (ModelState.IsValid && !(CandidatureExists(can.IdCandidature)))
            { 
                candidature.Insert(can);
                candidature.Save();
                return candidatures;
            } 
            else return null;
        }

        [HttpPut("{id}")]
        public Candidature Edit(int id, [Bind("IdCandidature,PrenomCandidat,NomCandidat,EtatCandidature,CV,IdTicket")] Candidature can)
        {
            if (id != can.IdCandidature)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    candidature.Update(can);
                    candidature.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatureExists(can.IdCandidature))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
                return can;
            }
            return can;
        }

        [HttpDelete("{id}")]
        public ActionResult<Candidature> DeleteConfirmed(int id)
        {
            Candidature _candidature = candidature.GetById(id);
            if (_candidature != null)
            {
                candidature.Delete(_candidature.IdCandidature);
                candidature.Save();
                return RedirectToAction("Index");
            }
            else return NotFound();
        }

        private bool CandidatureExists(int idCandidature)
        {
            IEnumerable<Candidature> candidatures = candidature.GetAll();
            bool test=false;
            foreach(Candidature can in candidatures)
            {
                if (can.IdCandidature == idCandidature)
                {
                    test = true;
                }
            }
            return test;
        }
    }
}