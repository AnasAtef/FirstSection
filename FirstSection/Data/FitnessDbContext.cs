using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FirstSection.Data.configuration;
using FirstSection.Data.configurations;

namespace FirstSection.Data
{
    public class FitnessDbContext : IdentityDbContext<APIUser>
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FirstSection.Data.Hotel> Hotel { get; set; } = default!;
        public DbSet<Training> Trainings { get; set; }

        public DbSet<FitnessCategory> FitnessCategory { get; set; }
        public DbSet<UserFitnessPlan> UserFitnessPlans { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionTraining> SessionTraining { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new FitnessCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
        }


    }
}
