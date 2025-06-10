using System.ComponentModel.DataAnnotations;

namespace FirstSection.Models.Users
{
    public class ApiUserDto : LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? Weight { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }

        public string GenderId { get; set; }


    }
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters ", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
