using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSkeleton4.Dtos;
using AutoMapper;
using Dominio.Entities;

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