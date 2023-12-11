using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Data.Dtos;

public class ReadEnderecoDto{
    public int IdEnd {get; set;}
     public string? Logradouro {get; set;}
     public int Numero {get; set;}
     public string? Bairro { get; set; }
     public string? Cidade { get; set; }
     public string? Estado { get; set; }
     public string? Cep { get; set; }
}