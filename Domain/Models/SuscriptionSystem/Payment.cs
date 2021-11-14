namespace jobagapi.Domain.Models.SuscriptionSystem
{
    public class Payment       
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        
        public float TotalAmount { get; set; }
        public string Details { get; set; }
    }
}