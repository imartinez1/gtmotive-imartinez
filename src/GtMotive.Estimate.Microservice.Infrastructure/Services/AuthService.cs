using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GtMotive.Estimate.Microservice.ApplicationCore.Identity;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GtMotive.Estimate.Microservice.Infrastructure.Services
{
    /// <summary>
    /// AuthService.
    /// </summary>
    /// <param name="jwtSettings">jwt settings.</param>
    public class AuthService(IOptions<JwtSettings> jwtSettings) : IAuthService
    {
        private readonly IOptions<JwtSettings> _jwtSettings = jwtSettings;

        /// <summary>
        /// GenerateJwt.
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns>token.</returns>
        public string GenerateJwt(User user)
        {
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.Value.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Value.Issuer,
                audience: _jwtSettings.Value.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
