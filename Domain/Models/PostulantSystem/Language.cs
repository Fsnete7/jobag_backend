using System.Collections.Generic;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Level { get; set; }
        
        public List<ProfileLanguage> ProfileLanguages { get; set; } 
        
    }
}