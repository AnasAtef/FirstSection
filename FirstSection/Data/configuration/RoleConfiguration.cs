using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstSection.Data.configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "e7b8a6f2-6f27-4dcb-bd8b-50805a789d3a",  // Fixed ID for Administrator
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "a2d965a4-7f9e-4cb0-8d44-52e2e8bb0cd2",  // Fixed ID for User
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
