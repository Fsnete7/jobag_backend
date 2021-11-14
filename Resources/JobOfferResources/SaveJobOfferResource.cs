using System;
using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.JobOfferResources
{
    public class SaveJobOfferResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        
        [Required]
        public double Salary { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Workplace { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Experience { get; set; }
    }
}