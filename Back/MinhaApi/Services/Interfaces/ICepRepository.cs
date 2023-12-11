using MinhaApi.Models;
namespace MinhaApi.Service.Interfaces;

public interface ICepRepository
{
  Task<Endereco> GetAsync(string cep);
}