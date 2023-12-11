using MinhaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaApi.Data;
public class UsuarioContext : DbContext
{
    public UsuarioContext(DbContextOptions<UsuarioContext> opts) : base(opts)
    {

    }

    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Endereco> Enderecos {get; set;}

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
            .HasKey(c => c.Cep);
            // Add any other additional configurations needed
        }

}