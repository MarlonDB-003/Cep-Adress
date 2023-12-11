using System.ComponentModel.DataAnnotations;


namespace MinhaApi.Models;

// ApplicationUser.cs
public class Usuario
{
    [Key]
    [Required]
    public int IdUser { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Login { get; set; }
    [Required]
    public string? Senha { get; set; }

    // public Endereco Endereco {get; set;}
}
