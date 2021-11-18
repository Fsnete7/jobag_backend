using System.Net.Mail;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace jobagapi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        //--------------- Sets Employer Bounded Context ---------------
        public  DbSet<Employer> Employers { get; set; }
        public  DbSet<Sector> Sectors { get; set; }
        public  DbSet<CompanyProfile> CompanyProfiles { get; set; }
        
        //--------------- Sets JobOffer Bounded Context ---------------
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        
        //--------------- Sets Subscription Bounded Context ---------------
        public DbSet<User> Users { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        //--------------- Sets Postulant Bounded Context ---------------
        
        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<ProfessionalProfile> Profiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        
        public DbSet<ProfileDegree> ProfileDegrees { get; set; }
        public DbSet<ProfileLanguage> ProfileLanguages { get; set; }
        public DbSet<ProfileSkill> ProfileSkills { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
             //--------------- Degrees ---------------
            // Constrains
            builder.Entity<Degree>().ToTable("Degrees");
            builder.Entity<Degree>().HasKey(p => p.Id);
            builder.Entity<Degree>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Degree>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Degree>().Property(p => p.Url).IsRequired().HasMaxLength(250);
            
            
            //--------------- Languages ---------------
            // Constrains
            builder.Entity<Language>().ToTable("Languages");
            builder.Entity<Language>().HasKey(p => p.Id);
            builder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Language>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Language>().Property(p => p.Level).IsRequired().HasMaxLength(250);

            //--------------- Skills ---------------
            // Constrains
            builder.Entity<Skill>().ToTable("Skills");
            builder.Entity<Skill>().HasKey(p => p.Id);
            builder.Entity<Skill>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Skill>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Skill>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            
            //--------------- Professional Profiles ---------------
            // Constrains
            builder.Entity<ProfessionalProfile>().ToTable("ProfessionalProfiles");
            builder.Entity<ProfessionalProfile>().HasKey(p => p.Id);
            builder.Entity<ProfessionalProfile>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Entity<ProfessionalProfile>().Property(p => p.Ocupation).IsRequired().HasMaxLength(50);
            builder.Entity<ProfessionalProfile>().Property(p => p.VideoUrl).IsRequired().HasMaxLength(250);
 
            
            // Relationships
            builder.Entity<ProfessionalProfile>()
                .HasOne(a => a.Postulant)
                .WithOne(u => u.ProfessionalProfile)
                .HasForeignKey<ProfessionalProfile>(a => a.postulantId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //--------------- Profiles Degrees ---------------
            // Constrains
            builder.Entity<ProfileDegree>().ToTable("ProfileDegrees");
            builder.Entity<ProfileDegree>().HasKey(p => new { p.DegreeId, p.ProfileId });
 
            // Relationships
            builder.Entity<ProfileDegree>()
                .HasOne(pt => pt.ProfessionalProfile)
                .WithMany(p => p.ProfileDegrees)
                .HasForeignKey(pt => pt.ProfileId);
            
            builder.Entity<ProfileDegree>()
                .HasOne(pt => pt.Degree)
                .WithMany(t => t.ProfileDegrees)
                .HasForeignKey(pt => pt.DegreeId);
            
            
            //--------------- Profiles Languages ---------------
            // Constrains
            builder.Entity<ProfileLanguage>().ToTable("ProfileLanguages");
            builder.Entity<ProfileLanguage>().HasKey(p => new { p.LanguageId, p.ProfileId });
            // Relationships
            builder.Entity<ProfileLanguage>()
                .HasOne(pt => pt.ProfessionalProfile)
                .WithMany(p => p.ProfileLanguages)
                .HasForeignKey(pt => pt.ProfileId);
            
            builder.Entity<ProfileLanguage>()
                .HasOne(pt => pt.Language)
                .WithMany(t => t.ProfileLanguages)
                .HasForeignKey(pt => pt.LanguageId);
                 
            //--------------- Profiles Skills ---------------
            // Constrains
            builder.Entity<ProfileSkill>().ToTable("ProfileSkills");
            builder.Entity<ProfileSkill>().HasKey(p => new { p.SkillId, p.ProfileId });
            // Relationships
            builder.Entity<ProfileSkill>()
                .HasOne(pt => pt.ProfessionalProfile)
                .WithMany(p => p.ProfileSkills)
                .HasForeignKey(pt => pt.ProfileId);
            
            builder.Entity<ProfileSkill>()
                .HasOne(pt => pt.Skill)
                .WithMany(t => t.ProfileSkills)
                .HasForeignKey(pt => pt.SkillId);
            
            //--------------- JobOffers ---------------
            // Constrains
            builder.Entity<JobOffer>().ToTable("JobOffers");
            builder.Entity<JobOffer>().HasKey(p => p.JobOfferId);
            builder.Entity<JobOffer>().Property(p => p.JobOfferId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<JobOffer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<JobOffer>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Entity<JobOffer>().Property(p => p.Workplace).IsRequired().HasMaxLength(50);
            
            // Relationships
            
            // Seed Data
            builder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    JobOfferId = 1, Name = "Intern Flutter Developer",
                    Description = "Develop apps for IOS and Android with one framework.",
                    Salary = 3200, Workplace = "Spotify", Type = "Develop", Experience = "None"
                }
            );

            //---------------- User -------
            // Constrains
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.UserId);
            builder.Entity<User>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.PhoneNumber).IsRequired();
            builder.Entity<User>().Property(p => p.PassWord).IsRequired().HasMaxLength(30);
            // Relationships
                //go to Payment
            // Seed Data
            builder.Entity<User>().HasData
            (
                new User
                {
                    UserId = 101,
                    FirstName = "Juan",
                    LastName = "Perez",
                    Email = "JuanPerez@gmail.com",
                    PhoneNumber = 987515252,
                    PassWord = "123"
                },
                new User
                {
                    UserId = 102,
                    FirstName = "Jose",
                    LastName = "Quispe",
                    Email = "JoseQuispe@gmail.com",
                    PhoneNumber = 981515252,
                    PassWord = "123"
                }
            );
            
            //---------------- Payment -------
            // Constrains
            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p => p.PaymentId);
            builder.Entity<Payment>().Property(p => p.PaymentId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.CarNumber).IsRequired();
            builder.Entity<Payment>().Property(p => p.AmountTotal).IsRequired();
            builder.Entity<Payment>().Property(p => p.Details).IsRequired().HasMaxLength(120);
            // Relationships
            builder.Entity<Payment>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Payment)
                .HasForeignKey(p => p.PaymentId);
            builder.Entity<Payment>()
                .HasMany(p => p.SubscriptionPlans)
                .WithOne(p => p.Payment)
                .HasForeignKey(p => p.PaymentId);
            // Seed Data
            builder.Entity<Payment>().HasData
            (
                new Payment
                {
                    PaymentId = 101,
                    CarNumber = 987515252,
                    AmountTotal = 130,
                    Details = "Detail1"
                },
                new Payment
                {
                    PaymentId = 102,
                    CarNumber = 915751555,
                    AmountTotal = 130,
                    Details = "Detail2"
                }
            );
            
            //--------------- SubscriptionPlan ---------------
            builder.Entity<SubscriptionPlan>().ToTable("SubscriptionPlans");
            builder.Entity<SubscriptionPlan>().HasKey(p => p.SubscriptionPlanId);
            builder.Entity<SubscriptionPlan>().Property(p => p.SubscriptionPlanId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SubscriptionPlan>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<SubscriptionPlan>().Property(p => p.LimitPostulation).IsRequired();
            builder.Entity<SubscriptionPlan>().Property(p => p.LimitVideoCreation).IsRequired();
            builder.Entity<SubscriptionPlan>().Property(p => p.PreDesignTemplates).IsRequired();
            builder.Entity<SubscriptionPlan>().Property(p => p.Duration).IsRequired();
            builder.Entity<SubscriptionPlan>().Property(p => p.LimitModification).IsRequired();
            builder.Entity<SubscriptionPlan>().Property(p => p.Assistance).IsRequired();
            // Relationships
                // Go to payment
            // Seed Data
            builder.Entity<SubscriptionPlan>().HasData
            (
                new SubscriptionPlan
                {
                    SubscriptionPlanId = 101,
                    Description = "Description1",
                    LimitPostulation = 5,
                    LimitVideoCreation = 30,
                    PreDesignTemplates = true,
                    Duration = 15,
                    LimitModification = 3,
                    Assistance = true,
                },
                new SubscriptionPlan
                {
                    SubscriptionPlanId = 102,
                    Description = "Description2",
                    LimitPostulation = 5,
                    LimitVideoCreation = 30,
                    PreDesignTemplates = true,
                    Duration = 15,
                    LimitModification = 3,
                    Assistance = false,
                }
            );
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}

