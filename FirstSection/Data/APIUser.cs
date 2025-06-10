using Microsoft.AspNetCore.Identity;

namespace FirstSection.Data
{
    public class APIUser:IdentityUser
    {
        public string FirstName {  get; set; }

        public string LastName { get; set; }

        public int? Weight { get; set; }

        public int? Age { get; set; }

        public int? Height { get; set; }


        public Guid GenderId { get; set; }
        public Gender Gender { get; set; }

    }
}
