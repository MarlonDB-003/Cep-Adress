using MinhaApi.Data;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data.Dtos;
using MinhaApi.Service.Interfaces;
using MinhaApi.Service;

namespace MinhaApi.Controllers;

// UsersController.cs
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase{
    private readonly UsuarioContext _context;
    private readonly IPasswordHasherService _passwordHasherService;

    public LoginController (UsuarioContext context, IPasswordHasherService passwordHasherService)
    {
        _context = context;
        _passwordHasherService =  passwordHasherService;
    }

    [HttpPost]
    public IActionResult AutenticarUsuario([FromBody] LoginUsuarioDto dtoUsuario)
    {
        var gerarTokenService = new GerarTokenService(_context);
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Login == dtoUsuario.Login);

        if (usuario != null)
        {
            var validarSenha = _passwordHasherService.VerifyPassword(dtoUsuario.Senha, usuario.Senha);

            if (validarSenha)
            {
                var token = gerarTokenService.GerarToken(usuario.Nome);
                return Ok(token);
            }
        }

        return Unauthorized();

    }
}