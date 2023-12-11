using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Data.Dtos;
using MinhaApi.Models;

namespace MinhaApi.Service;

public class UserService
{
    private readonly UsuarioContext _context;
    private SignInManager<Usuario> _signInManager;

    public UserService(UsuarioContext context, SignInManager<Usuario> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

}