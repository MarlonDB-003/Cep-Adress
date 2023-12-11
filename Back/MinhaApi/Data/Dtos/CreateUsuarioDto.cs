using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class CreateUsuarioDto{
    [Required (ErrorMessage = "O nome é obrigatório.")]
    public string? Nome {get; set;}

    [Required (ErrorMessage = "O login é obrigatório.")]
    public string? Login {get; set;}  
    [Required (ErrorMessage = "A senha é obrigatório.")]
    public string? Senha {get; set;}       
}