using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class UpdateEnderecoDto{
    [Required]
    public string? Logradouro {get; set;}
    [Required]
    public int Numero {get; set;}
    [Required]
    public string? Bairro {get; set;}
    [Required]
    public string? Cidade {get; set;}
    [Required]
    public string? Estado {get; set;}
    [Required]
    public string? Cep {get; set;}

}