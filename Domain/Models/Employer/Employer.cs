using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Models
{
    public class Employer : User
    {
        public int Id { get; set; }
        public int Position { get; set; }
    }
}