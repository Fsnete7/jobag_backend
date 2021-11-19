namespace jobagapi.Domain.Models.PostulantSystem
{
    public class ProfileSkill
    {
        public int ProfileId { get; set; }
        public ProfessionalProfile ProfessionalProfile { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}