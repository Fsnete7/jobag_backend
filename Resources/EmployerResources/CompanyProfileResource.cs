
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Resources.EmployerResources
{
    public class CompanyProfileResource
    {
        public int Id { get; set; }
        public string Direction { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int EmployerId { get; set; }
    }
}