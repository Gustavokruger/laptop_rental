using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using laptop_rental;
using laptop_rental.Domain;
using laptop_rental.Domain.Customers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class GenerateTokenService : IGenerateTokenService
{
    private readonly IOptions<AppSettings> _settings;
    public GenerateTokenService(IOptions<AppSettings> settings)
    {
        _settings = settings;

    }
    public string generateToken(Customer customer)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Value.secret);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, customer.Email.ToString()),
                new Claim(ClaimTypes.Name, customer.FullName.ToString())

            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
            new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        });

        return tokenHandler.WriteToken(token);
    }
}
