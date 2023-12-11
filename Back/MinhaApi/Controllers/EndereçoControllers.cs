using AutoMapper;
using MinhaApi.Data;
using MinhaApi.Data.Dtos;
using MinhaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using MinhaApi.Service;

namespace MinhaApi.Controllers;

// EnderecoController.cs
[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private UsuarioContext _context;
    private IMapper _mapper;

    public EnderecoController (UsuarioContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    /*Recebe uma EnderecoDto e converte em Endereco*/
    [HttpPost("cad")]
    public async Task<IActionResult> CriarEndereco ([FromBody] CreateEnderecoDto dto){
        Endereco endereco = new(){
            Logradouro = dto.Logradouro,
            Numero = dto.Numero,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            Cep = dto.Cep
        };
        
        _mapper.Map<Endereco>(dto);
        CepValidarService cepValidarService = new CepValidarService();
        Endereco enderecoViaCEP = await cepValidarService.ConsultarCEP(dto);

        if (enderecoViaCEP != null){
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            CreatedAtAction(nameof(RecuperarEnderecoPorId),
                new{id = endereco.IdEnd}, endereco);
            
            return Ok("CEP válido. Endereço salvo no banco de dados.");
        }
        
        return NotFound("CEP inválido ou não encontrado.");
        

    }


    /*Recebe cada Endereco e transforma em uma lista de ReadEnderecoDto*/
    [HttpGet("Listar")]
    public IEnumerable<ReadEnderecoDto> RecuperarEndereco ()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.OrderBy(endereco => endereco.IdEnd).ToList());
    }

    /*Recebe o Endereco e converte em uma ReadEnderecoDto*/
    [HttpGet("{id}")]
    public IActionResult RecuperarEnderecoPorId(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEnd == id);
        if(endereco != null)
        {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }else
        {
            return NotFound($"Endereco não encontrada");
        }
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarEnderecoPatch(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEnd == id);
        if (endereco == null)
        {
            return NotFound("Endereco não encontrada :(");
        }else
        {
            var enderecoParaAtualizar = _mapper.Map<UpdateEnderecoDto>(endereco);
            patch.ApplyTo(enderecoParaAtualizar, ModelState);
            if(!TryValidateModel(enderecoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }else
            {
                _mapper.Map(enderecoParaAtualizar, endereco);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }

    [HttpDelete("Deletar")]
    public IActionResult DeletarEndereco([FromBody] DeleteEnderecoDto dto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEnd == dto.IdEnd);
        if (endereco == null)
        {
            return NotFound("Endereco não encotrada :(");
        }else
        {
            _context.Remove(endereco);
            _context.SaveChanges();
            return Ok("Deletado com sucesso");
        }
    }
}