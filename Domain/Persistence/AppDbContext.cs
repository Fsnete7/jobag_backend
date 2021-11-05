using jobagapi.Domain.Models;
using jobagapi.Domain.Models.PostulantSystem;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Domain.Persistence
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Sector>  Sectors { get; set; }
        public DbSet<Employeer> Employeers { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<MailMessage> MailMessages { get; set; } 
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<ProfessionalProfile> ProfessionalProfiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users  { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
    
   }