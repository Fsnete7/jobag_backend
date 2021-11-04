using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Models
{
    public class Employeer : User
    {
        public int Id { get; set; }
        public int Position { get; set; }
    }
}