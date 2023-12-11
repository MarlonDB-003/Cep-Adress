using AutoMapper;
using MinhaApi.Data.Dtos;
using MinhaApi.Models;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, CreateEnderecoDto>();
        CreateMap<Endereco,ReadEnderecoDto>();
        CreateMap<ReadEnderecoDto, Endereco>();
        CreateMap<Endereco,UpdateEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}