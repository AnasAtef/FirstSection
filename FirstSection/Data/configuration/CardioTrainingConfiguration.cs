using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSection.Data.configurations
{
    public class CardioTrainingConfiguration : IEntityTypeConfiguration<CardioTraining>
    {
        public void Configure(EntityTypeBuilder<CardioTraining> builder)
        {
            builder.HasData(
                new CardioTraining
                {
                    Id = new Guid("5FAE9D1B-E8A5-436B-B342-AB3AB86AF86B"),
                    Name = "2-Day",
                    Description = "Steady-state cardio with moderate intensity including treadmill walking and cycling, combined with a light interval session for beginners.",
                    NumberOfDays = 2,
                    FitnessCategoryId=2
                },
                new CardioTraining
                {
                    Id = new  Guid("C305CD4E-842A-4853-B3F1-7C33B39B4A26") ,
                    Name = "3-Day",
                    Description = "A mix of steady-state cardio and HIIT workouts designed for improved stamina and fat burning with balanced intensity progression.",
                    NumberOfDays = 3,
                    FitnessCategoryId = 2
                },
                new CardioTraining
                {
                    Id = new  Guid("83B922AA-578E-44A2-B985-0A0982C70BEB"),
                    Name = "4-Day",
                    Description = "Alternates between endurance sessions at moderate pace and high-intensity interval training for balanced cardiovascular development.",
                    NumberOfDays = 4,
                    FitnessCategoryId = 2
                },
                new CardioTraining
                {
                    Id = new  Guid("8CF63A99-D589-4541-8F30-E270D9AC8C68") ,
                    Name = "5-Day",
                    Description = "Comprehensive aerobic and anaerobic conditioning including sprints, jump rope, and stair climbing for advanced cardiovascular fitness.",
                    NumberOfDays = 5,
                    FitnessCategoryId = 2
                },
                new CardioTraining
                {
                    Id = new Guid("27AAF090-D342-4DB3-A1E4-5030F1FFED61"),
                    Name = "6-Day",
                    Description = "Structured mix of HIIT, steady-state, and sport-based cardio including rowing and agility drills for advanced endurance training.",
                    NumberOfDays = 6,
                    FitnessCategoryId = 2
                }
            );
        }
    }
}
