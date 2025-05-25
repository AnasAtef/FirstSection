using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSection.Data.configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData
                (
                new Country
                {
                    CountryId = 2,
                    Name="Jamaica",
                    ShortName="JAM"
                },
                new Country
                {
                    CountryId = 8,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    CountryId =9,
                    Name = "Iceland",
                    ShortName = "ICE"
                }
                );
        }
    }
}
