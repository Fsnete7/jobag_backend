using jobagapi.Domain.Models;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        
        public  DbSet<Employer> Employers { get; set; }
        public  DbSet<Sector> Sectors { get; set; }
        public  DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<MailMessage> MailMessages { get; set; }
        
        //--------------- Sets Subscription ---------------
        public DbSet<User> Users { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
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
            builder.Entity<MailMessage>().ToTable("Messages");
            builder.Entity<MailMessage>().HasKey(p => p.Id);
            builder.Entity<MailMessage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MailMessage>().Property(p => p.Message).IsRequired();
            
            // Relationships
            
            
            // Seed Data
            builder.Entity<MailMessage>().HasData(
                new MailMessage
                    { Id = 1, Message = "Hola, que te parece jobag?" }
            );
            */
            //---------------- Subscription Bounded Content -------
            
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
                //go to postulant, employeer or Payment
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
                // :C
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

