using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace FirstSection.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<APIUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthManager(IMapper mapper, UserManager<APIUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;  // Corrected the assignment
            this._userManager = userManager;
            this._configuration = configuration;
        }



        public IMapper Mapper => _mapper; // Correct property getter

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (user == null || isValidUser == false)
            {

                return null;
            }



            var token = await GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id
            };



        }


        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            // Map userDto to APIUser
            var user = _mapper.Map<APIUser>(userDto);
            user.UserName = userDto.Email;  // Set the UserName to be the email

            // Check if the username (email) already exists
            var existingUser = await _userManager.FindByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                // If a user with the same email exists, return an error
                return new List<IdentityError>
                {
                    new IdentityError
                    {
                        Code = "DuplicateUsername",
                        Description = "The username (email) is already taken."
                    }
                };
            }

            // Create the user if no duplicates
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                // Add default role after successful registration
                await _userManager.AddToRoleAsync(user, "User");
            }

            // Return the errors from the result if the creation fails
            return result.Errors;
        }


        private async Task<string> GenerateToken(APIUser user)
        {
            // 🔍 Use configuration instead of hardcoded values
            var key = _configuration["JwtSettings:Key"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var durationInMinutes = Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"]);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("nameid", user.Id), // This matches your controller GetCurrentUserId() method
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
    };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim("role", role)));

            // 🔧 Use HMAC SHA256 to match your Program.cs validation
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(durationInMinutes),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
