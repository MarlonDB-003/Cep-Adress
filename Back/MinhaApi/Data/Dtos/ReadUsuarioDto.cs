using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class ReadUsuarioDto {
    public int IdUser {get; set;}
    public string? Nome {get; set;}
    public string? Login {get; set;}
    public string? Senha { get; set; }
}