
using DevopsAPI.Data.Entities;
using DevopsAPI.Models.Dto.Response;
using DevopsAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace DevopsAPI.Services.Implementations
{
    public class TokenHandler : IToken
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //jwt token generasiya olunmasi
        public string CreateToken(AppUser user, string membership)
        {

            var authClaims = CreateClaims(user, membership);
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(180),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        //user melumatlarina ve roluna gore claimlarin yigilmasi
        private static List<Claim> CreateClaims(AppUser user, string membership)
        {
            return new List<Claim>
            {
                new Claim("id", Guid.NewGuid().ToString()),
                new Claim("user", JsonSerializer.Serialize(new UserClaim
                {
                    Id = user.Id,
                    Email = user.Email,
                    CreatedDate = user.CreatedDate
                }), JsonClaimValueTypes.Json),
                new Claim("membership", membership)
            };
        }


        //public JwtTokenClaims DecodeToken(string token)
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    if(token == null)
        //        return null;
        //    var decoded = handler.ReadJwtToken(token.Replace("Bearer ", ""));

        //    return new JwtTokenClaims
        //    {
        //        TokenId = decoded.Claims.First(claim => claim.Type == "tokenId").Value,
        //        Account = JsonConvert.DeserializeObject<AccountClaim>(decoded.Claims.First(claim => claim.Type == "user").Value),
        //        Role = decoded.Claims.First(claim => claim.Type == "role").Value,
        //        Branches = decoded.Claims.First(claim => claim.Type == "branches").Value
        //    };
        //}
    }
}
