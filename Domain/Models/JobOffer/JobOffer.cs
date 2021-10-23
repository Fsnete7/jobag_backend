using System;

namespace jobagapi.Domain.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Salary { get; set; }
        public string Description { get; set; }
        public string Workplace { get; set; }
        public DateTime Date { get; set; }
        public string Experience { get; set; }
    }
}