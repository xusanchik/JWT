using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT.Models;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Servise;

public class GeneretTokenServies
{
    private readonly IConfiguration _configuration;

    public GeneretTokenServies(IConfiguration configuration) => _configuration = configuration;
    public string GetToken(User user)
    {

        return token;
    }
    public JwtSecurityToken GetJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);


        return new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials
            );
    }
    private List<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("Userid" , user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),

}