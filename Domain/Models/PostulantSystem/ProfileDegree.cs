namespace jobagapi.Domain.Models.PostulantSystem
{
    public class ProfileDegree
    {
        public int ProfileId { get; set; }
        public ProfessionalProfile ProfessionalProfile { get; set; }
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
    }
}