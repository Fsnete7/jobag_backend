using System;
using System.Collections.Generic;
using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Resources.JobOfferResources
{
    public class JobOfferResource
    {
        public int JobOfferId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Salary { get; set; }
        public string Description { get; set; }
        public string Workplace { get; set; }
        public DateTime Date { get; set; }
        public string Experience { get; set; }
    }
}