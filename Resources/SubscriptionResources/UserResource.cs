using System;

namespace jobagapi.Resources.SubscriptionResources
{
    public class UserResource
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string PassWord { get; set; }
    }
}