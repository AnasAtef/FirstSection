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

        public AuthManager(IMapper mapper, UserManager<APIUser> userManager,IConfiguration configuration)
        {
            _mapper = mapper;  // Corrected the assignment
            this._userManager = userManager;
            this._configuration = configuration;
        }

       

        public IMapper Mapper => _mapper; // Correct property getter

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user =await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (user==null||isValidUser==false)
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


        private async Task<string>GenerateToken(APIUser user) 
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var RoleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var UserClaims = await _userManager.GetClaimsAsync(user);
            var Claims = new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.Sub, user.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Email, user.Email),


            }.Union(UserClaims).Union(RoleClaims);


            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audiance"],
                claims: Claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings: DurationInMinutes"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
