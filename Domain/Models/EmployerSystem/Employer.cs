using System.Collections;
using System.Collections.Generic;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Models.EmployerSystem
{
    public class Employer : User
    {
        public string Position { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
    }
}