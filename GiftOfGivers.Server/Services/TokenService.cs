using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GiftOfGivers.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config) => _config = config;

        public string BuildToken(string userId, string email, IEnumerable<string> roles, IDictionary<string,string>? extraClaims = null)
        {
            var key = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
            var issuer = _config["Jwt:Issuer"] ?? "gift-of-givers";
            var audience = _config["Jwt:Audience"] ?? "gift-of-givers-client";
            var expiryMinutes = int.TryParse(_config["Jwt:ExpiryMinutes"], out var m) ? m : 60 * 24; // Default to 1 day

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("uid", userId)
            };

            foreach (var r in roles.Distinct())
                claims.Add(new Claim(ClaimTypes.Role, r));

            if (extraClaims != null)
            {
                foreach (var k in extraClaims.Keys)
                {
                    claims.Add(new Claim(k, extraClaims[k]));
                }
            }

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var secKey = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}