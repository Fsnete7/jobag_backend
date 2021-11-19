using System;
using System.Collections.Generic;

namespace jobagapi.Domain.Models.JobOfferSystem
{
    public class JobOffer
    {
        public int JobOfferId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Salary { get; set; }
        public string Description { get; set; }
        public string Workplace { get; set; }
        public DateTime Date { get; set; }
        public string Experience { get; set; }
        
        public Contract Contract { get; set; }
        public List<Postulation> Postulations { get; set; }
        public List<Interview> Interviews { get; set; }
    }
}