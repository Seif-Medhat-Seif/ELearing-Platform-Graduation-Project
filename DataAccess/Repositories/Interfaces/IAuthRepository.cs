using ELProject.Domain.Models;
using ELProject.Shared.DTOs.Auth;
using ELProject.Shared.Results;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ELProject.DataAccess.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthResult> RegisterAsync(RegisterDto UserDto);
        Task<AuthResult> LoginAsync(LoginDto dto);
        Task<AuthResult> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<AuthResult> ExternalLoginAsync(ExternalLoginDto model);
        Task<AuthResult> ChangePasswordAsync(ClaimsPrincipal userFromClaims, ChangePasswordDto dto);
        Task<JwtSecurityToken> GetTokenAsync(ApplicationUser user);
    }
}
