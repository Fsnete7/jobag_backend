namespace jobagapi.Domain.Models.SuscriptionSystem
{
    public class SuscriptionPlan
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PostulationLimits{ get; set; }
        public int VideoCreationLimits { get; set; }
        public bool PreDesignTemplate { get; set; }
        public bool Duration { get; set; }
        public bool VideoconferenceLimit { get; set; }
        public bool Assistance { get; set; }
        
        //relationShip
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}