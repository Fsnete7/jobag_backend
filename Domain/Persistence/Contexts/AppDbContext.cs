using jobagapi.Domain.Models.PostulantSystem;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>   Users          { get; set; }
        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<ProfessionalProfile> Profiles { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
            
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ======================= Postulant Entity =======================
            modelBuilder.Entity<Postulant>().ToTable("Postulants");
            
            modelBuilder.Entity<Postulant>().HasKey(p => p.Id);
            modelBuilder.Entity<Postulant>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Postulant>().Property(p => p.Firstname)
                .IsRequired();
            modelBuilder.Entity<Postulant>().Property(p => p.Lastname)
                .IsRequired();
            modelBuilder.Entity<Postulant>().Property(p => p.PhoneNumber)
                .IsRequired(false);
            modelBuilder.Entity<Postulant>().Property(p => p.Email)
                .IsRequired();
            modelBuilder.Entity<Postulant>().Property(p => p.Password)
                .IsRequired();
            modelBuilder.Entity<Postulant>().Property(p => p.Dni)
                .IsRequired();
            modelBuilder.Entity<Postulant>().Property(p => p.Birthday)
                .IsRequired();
            modelBuilder.Entity<Postulant>().Property(p => p.CivilStatus)
                .IsRequired(false);
            
            modelBuilder.Entity<Postulant>()
                .HasOne(a => a.Profile)
                .WithOne(u => u.Postulant)
                .HasForeignKey<Postulant>(a => a.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // ================================================================
            
            // ======================= Postulant Entity =======================
            // ================================================================
            
            // ======================= Profile Entity =======================
            // ================================================================
            
            // ======================= Language Entity =======================
            // ================================================================
            
            // ======================= Skill Entity =======================
            // ================================================================
            
            // ======================= Degree Entity =======================
            // ================================================================
        }
            
    }
}