using System;

using System.ComponentModel.DataAnnotations;
namespace jobagapi.Resources.EmployerResources
{
    public class SectorResource
    {
        public int Id { get; set; }
        public string Name { set; get; }
        
        public string Description { set; get; }
    }
}