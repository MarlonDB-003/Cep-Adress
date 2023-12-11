using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MinhaApi.Data;


namespace MinhaApi.Service;

public class GerarTokenService{
    private readonly UsuarioContext _context;
    private readonly string chaveSecreta = "sua_chave_secreta_para_assinatura_do_token";

    public GerarTokenService (UsuarioContext context)
    {
        _context = context;
    }

        public string GerarToken(string nomeUsuario)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, nomeUsuario)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "bemol",
            audience: "end_test",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}