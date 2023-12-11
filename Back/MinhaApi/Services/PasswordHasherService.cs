using System.Security.Cryptography;
using System.Text;
using MinhaApi.Service.Interfaces;

namespace MinhaApi.Service;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string? senha)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha ?? string.Empty));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return  builder.ToString();
        }
    }

    public bool VerifyPassword(string? senha, string? hashedSenha)
    {
        return hashedSenha == HashPassword(senha);
    }
}