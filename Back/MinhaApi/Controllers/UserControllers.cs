using AutoMapper;
using MinhaApi.Data;
using MinhaApi.Data.Dtos;
using MinhaApi.Models;
using MinhaApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using MinhaApi.Service.Interfaces;

namespace MinhaApi.Controllers;

// UsersController.cs
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioContext _context;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IMapper _mapper;

    public UsuarioController (UsuarioContext context, IPasswordHasherService passwordHasherService, IMapper mapper)
    {
        _context = context;
        _passwordHasherService = passwordHasherService;
        _mapper = mapper;
    }

    /*Recebe um UsuárioDto e converte em Usuário*/
    [HttpPost]
    public async Task<IActionResult> CriarUsuario ([FromBody] CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = new(){
            Nome = usuarioDto.Nome,
            Login = usuarioDto.Login,
            Senha = _passwordHasherService.HashPassword(usuarioDto.Senha)
        };
        
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(RecuperarUsuarioPorId),
            new {id = usuario.IdUser}, usuario);
    }

    /*Recebe cada usuario e transforma em uma lista de ReadusuarioDto*/
    [HttpGet("Listar")]
    public IEnumerable<ReadUsuarioDto> RecuperarUsuario ()
    {
           return _mapper.Map<List<ReadUsuarioDto>>(_context.Usuarios.OrderBy(usuario => usuario.Nome).ToList());
    }

    /*Recebe o usuario e converte em uma ReadUsuarioDto*/
    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarUsuarioPorId(int id)
    {
        var user = await _context.Usuarios.FindAsync(id);

        return user == null ? NotFound() : Ok(user);
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarUsuarioPatch(int id, JsonPatchDocument<UpdateUsuarioDto> patch)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUser == id);
        if (usuario == null)
        {
            return NotFound("Usuário não encontrada :(");
        }else
        {
            var usuarioParaAtualizar = _mapper.Map<UpdateUsuarioDto>(usuario);
            patch.ApplyTo(usuarioParaAtualizar, ModelState);
            if(!TryValidateModel(usuarioParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }else
            {
                _mapper.Map(usuarioParaAtualizar, usuario);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarUsuario(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUser == id);
        if (usuario == null)
        {
            return NotFound("Usuário não encotrada :(");
        }else
        {
            _context.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }

}