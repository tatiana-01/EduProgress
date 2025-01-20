using AutoMapper;
using Domain.Entities;
using EduProgressApi.Dtos;

namespace ApiSkeleton4.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<Rol, RolPostDto>().ReverseMap();
        CreateMap<Rol, RolGetAllDto>().ReverseMap();

        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuario, UsuarioGetAllDto>().ReverseMap();

        CreateMap<UsuarioRol, UsuarioRolDto>().ReverseMap();
    }
}