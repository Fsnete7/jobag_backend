using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Models.SubscriptionSystem
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string PassWord { get; set; }
        
 
        
        //RelationShip - Payment
        public int PaymentId { get; set; }
        public Payment Payment{ get; set; }
        
 
    }
}