using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class CreateEnderecoDto{
    [Required]
    public string? Logradouro {get; set;}
    
    [Required]
    public string? Numero {get; set;}

    [Required]
    public string? Bairro {get; set;}

    [Required]
    public string? Cidade {get; set;}

    [Required]
    public string? Estado {get; set;}

    [Required]
    [MaxLength(8, ErrorMessage = "O CEP não pode exceder 8 caracteres.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "O CEP deve conter apenas números.")]
    public string? Cep {get; set;}

}