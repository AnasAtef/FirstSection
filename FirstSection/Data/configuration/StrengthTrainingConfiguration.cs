using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSection.Data.configurations
{
    public class StrengthTrainingConfiguration : IEntityTypeConfiguration<StrengthTraining>
    {
        public void Configure(EntityTypeBuilder<StrengthTraining> builder)
        {
            builder.HasData(
          new StrengthTraining
          {
              Id = new Guid("F6A88AC7-C89E-4E33-B408-459F67855B0E"),
              Name = "2-Day",
              Description = "Upper/Lower split designed for those who can commit to 2 days per week at the gym, alternating between upper body and lower body training sessions.",
              NumberOfDays = 2,
              FitnessCategoryId = 1
          },
          new StrengthTraining
          {
              Id = new Guid("a935dc47-736f-49cd-b91e-f078e638d4e2"),
              Name = "3-Day",
              Description = "Push-Pull-Legs (PPL) routine for 3 days per week, focusing on pushing movements, pulling movements, and leg exercises in separate sessions.",
              NumberOfDays = 3,
              FitnessCategoryId = 1
          },
          new StrengthTraining
          {
              Id = new Guid("D924DE9B-3781-49D2-BE5A-7F7219EC8A10"),
              Name = "4-Day",
              Description = "A well-balanced routine optimized for four days of training per week, providing comprehensive muscle development with adequate recovery time.",
              NumberOfDays = 4,
              FitnessCategoryId = 1
          },
          new StrengthTraining
          {
              Id = new Guid("861EE843-D417-4671-8E5D-D00D7D0CE3DC"),
              Name = "5-Day",
              Description = "Arnold Split routine for 5 days per week, known for its focus on muscle group variations and high training frequency for advanced lifters.",
              NumberOfDays = 5,
              FitnessCategoryId = 1
          },
          new StrengthTraining
          {
              Id = new Guid("E33DFE70-63EA-4429-BF83-D4D0B427822F"),
              Name = "6-Day",
              Description = "Push-Pull-Legs (PPL) performed twice per week for increased training volume, designed for experienced lifters seeking maximum muscle growth.",
              NumberOfDays = 6,
              FitnessCategoryId = 1
          }
         );
        }
    }
}
