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
        public double Duration { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public bool Pending { get; set; }
        
        [Required]
        public int JobOfferId { get; set; }
        [Required]
        public int PostulantId { get; set; }
    }
}