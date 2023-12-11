using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int IdEnd { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Cep { get; set; }
    public string? Numero { get; internal set; }
}