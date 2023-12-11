using AutoMapper;
using MinhaApi.Data.Dtos;
using MinhaApi.Models;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<Usuario, CreateUsuarioDto>();
        CreateMap<Usuario,ReadUsuarioDto>();
        CreateMap<Usuario,UpdateUsuarioDto>();
        CreateMap<UpdateUsuarioDto, Usuario>();
    }
}