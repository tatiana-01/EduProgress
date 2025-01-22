using Application.Dtos;
using AutoMapper;
using Domain.Entities;


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
        CreateMap<Curso, CursoDto>().ReverseMap();
    }
}