using jobagapi.Domain.Models.SuscriptionSystem;

namespace jobagapi.Domain.Models.EmployerSystem
{
    public class Employer : User
    {
        public int Id { get; set; }
        public int Position { get; set; }
    }
}