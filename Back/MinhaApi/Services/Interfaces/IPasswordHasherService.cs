namespace MinhaApi.Service.Interfaces;

public interface IPasswordHasherService
{
    string HashPassword(string? senha);
    bool VerifyPassword(string? senha, string? hashedSenha);
}