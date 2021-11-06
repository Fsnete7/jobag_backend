using jobagapi.Domain.Models;
using jobagapi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<MailMessage> MailMessages { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //--------------- JobOffers ---------------
            // Constrains
            builder.Entity<JobOffer>().ToTable("JobOffers");
            builder.Entity<JobOffer>().HasKey(p => p.Id);
            builder.Entity<JobOffer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<JobOffer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<JobOffer>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Entity<JobOffer>().Property(p => p.Workplace).IsRequired().HasMaxLength(50);
            
            // Relationships
            
            // Seed Data
            builder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = 1, Name = "Intern Flutter Developer",
                    Description = "Develop apps for IOS and Android with one framework.",
                    Salary = 3200, Workplace = "Spotify", Type = "Develop", Experience = "None"
                }
            );
            
            //--------------- Mail Messages ---------------
            // Constrains
            builder.Entity<MailMessage>().ToTable("JobOffers");
            builder.Entity<MailMessage>().HasKey(p => p.Id);
            builder.Entity<MailMessage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MailMessage>().Property(p => p.Message).IsRequired();
            
            // Relationships
            
            
            // Seed Data
            builder.Entity<MailMessage>().HasData(
                new MailMessage
                    { Id = 1, Message = "Hola, que te parece jobag?" }
            );
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}