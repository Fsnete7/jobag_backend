namespace jobagapi.Domain.Models.PostulantSystem
{
    public class ProfileLanguage
    {
        public int ProfileId { get; set; }
        public ProfessionalProfile ProfessionalProfile { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}