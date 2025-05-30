﻿        using FirstSection.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace FirstSection.Contracts
{
    public interface IAuthManager 
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);


    }
}
