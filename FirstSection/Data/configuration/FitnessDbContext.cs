using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace FirstSection.Data.configuration
{
    public class FitnessDbContext : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData
                (
                  new Hotel
                  {
                      Id = 1,
                      Name = "Hilton Hotel",
                      Address = "123 Ocean Drive",
                      Rating = 4.5,
                      CountryId = 1
                  },
        new Hotel
        {
            Id = 2,
            Name = "Marriott Hotel",
            Address = "456 Mountain Road",
            Rating = 4.2,
            CountryId = 2
        },
        new Hotel
        {
            Id = 3,
            Name = "Sunset Resort",
            Address = "789 Beach Avenue",
            Rating = 4.8,
            CountryId = 1
        }
    );
               
        }
    }
}
