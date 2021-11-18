using System.Collections.Generic;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        
        public List<ProfileSkill> ProfileSkills { get; set; }  
    }
}