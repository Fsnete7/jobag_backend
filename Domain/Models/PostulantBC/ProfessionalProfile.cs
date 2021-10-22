using System.Collections.Generic;

namespace jobagapi.Domain.Models.PostulantBC
{
    public class ProfessionalProfile{

        public int Id { get; set; }
        public string Ocupation { get; set; }

        public string VideoUrl { get; set; }

        public List<Language> Languages { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Degree> Degrees { get; set; }
    }
}