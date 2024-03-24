using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Models.Users;
using Data.Utils;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Util;

public static class JwtHelper
{
    public static string GenerateToken(UserModel model, IConfiguration configuration,
        Func<UserModel, IEnumerable<Claim>> claimSelector)
    {
        var claims = claimSelector(model);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTimeHelper.ConvertUtcToVnTime().AddDays(30),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}