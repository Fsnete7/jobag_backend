using System.Collections.Generic;
using System.IO;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class Degree
    {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public string Url { get; set; }
            
            public List<ProfileDegree> ProfileDegrees { get; set; }
        
    }
}