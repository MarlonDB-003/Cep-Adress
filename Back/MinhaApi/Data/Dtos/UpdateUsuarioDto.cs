using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class UpdateUsuarioDto{
    [Required]
    public string? Nome {get; set;}

    [Required]
    public string? login {get; set;}

    [Required]
    public string? senha {get; set;}
}