using Microsoft.AspNetCore.Identity;

namespace FirstSection.Data
{
    public class APIUser:IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }

    }
}
