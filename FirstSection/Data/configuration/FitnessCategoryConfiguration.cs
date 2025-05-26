using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSection.Data.configurations
{
    public class FitnessCategoryConfiguration : IEntityTypeConfiguration<FitnessCategory>
    {
        public void Configure(EntityTypeBuilder<FitnessCategory> builder)
        {
            builder.HasData(
                new FitnessCategory
                {
                    Id = 1,
                    Name = "Strength",
                    Description = "Resistance training exercises focused on building muscle mass, increasing power, and improving overall physical strength using weights, resistance bands, or bodyweight movements."
                },
                new FitnessCategory
                {
                    Id = 2,
                    Name = "Cardio",
                    Description = "Cardiovascular exercises that elevate heart rate and improve endurance, including running, cycling, swimming, and other aerobic activities that strengthen the heart and lungs."
                }
            );
        }
    }
}
