using System;
using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.JobOfferResources
{
    public class SaveInterviewResource
    {
        [Required]
        [MaxLength(250)]
        public string Link { get; set; }
        
        [Required]
        [MaxLength(30)]
        public double Duration { get; set; }
        
        [Required]
        [MaxLength(30)]
        public DateTime StartDate { get; set; }
        
        [Required]
        [MaxLength(30)]
        public bool Pending { get; set; }
    }
}