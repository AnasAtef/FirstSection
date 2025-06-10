using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSection.Data.configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(
                new Gender
                {
                    Id = new Guid("DF230142-A19B-4A42-AE6E-3A06688E8FD7"),  // Fixed ID for Administrator
                    Name="Male"
                },
                new Gender
                {
                    Id = new Guid("C7692553-10A5-45F6-9438-5CB30A0A2FA1"),  // Fixed ID for Administrator
                    Name = "Female"
                }
            );
        }
    }
}
