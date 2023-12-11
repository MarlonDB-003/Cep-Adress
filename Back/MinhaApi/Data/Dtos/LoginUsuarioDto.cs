using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class LoginUsuarioDto{
    
    [Required (ErrorMessage = "O login é obrigatório.")]
    public string? Login {get; set;}

    [Required (ErrorMessage = "A senha é obrigatório.")]
    public string? Senha {get; set;}
}