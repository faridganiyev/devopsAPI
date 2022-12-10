using DevopsAPI.Data.Entities;

namespace DevopsAPI.Services.Interfaces
{
    public interface IToken
    {
        string CreateToken(AppUser user, string membership);
        //JwtTokenClaims DecodeToken(string token);
    }
}
