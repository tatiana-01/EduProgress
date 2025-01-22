
using EduProgressApi.Helpers;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EduProgressApi.Helpers.Autorizacion;
using Application.Dtos;

namespace EduProgressApi.Controllers;

public class UsuarioRolController : BaseApiController
{
    private readonly IUsuarioRol _usuarioRol;
    private readonly IMapper _mapper;

    public UsuarioRolController(IUsuarioRol usuarioRol, IMapper mapper)
    {
        _usuarioRol = usuarioRol;
        _mapper = mapper;
    }


    [HttpGet]
    [Authorize]
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UsuarioRolDto>>> GetPaginaUsuarioRol([FromQuery] Params usuarioParams)
    {
        var usuariosRoles = await _usuarioRol.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);

        var lstUsuRolDto = _mapper.Map<List<UsuarioRolDto>>(usuariosRoles.registros);

        return new Pager<UsuarioRolDto>(lstUsuRolDto, usuariosRoles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    [HttpGet("{idUsuario}/{idRol}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioRolDto>> GetByIdUsuarioRol( int idUsuario, int idRol)
    {
        var usuarioRol = await _usuarioRol.GetByIdAsync(idUsuario, idRol);

        if (usuarioRol == null) {
            return NotFound();
        }

        return _mapper.Map<UsuarioRolDto>(usuarioRol);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioRolDto>> Post(UsuarioRolDto usuarioRolDto)
    {
        var usuarioRol = _mapper.Map<UsuarioRol>(usuarioRolDto);
        var response = await _usuarioRol.Add(usuarioRol);
        if (response < 0)
        {
            return BadRequest();
        }

        return _mapper.Map<UsuarioRolDto>(usuarioRol);
    }

    [HttpPut("{idUsuario}/{idRol}")]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioRolDto>> Put(int idUsuario, int idRol, [FromBody] UsuarioRolDto usuarioRolDto)
    {
        if (usuarioRolDto == null) {
            return NotFound();
        }

        var usuarioRol = _mapper.Map<UsuarioRol>(usuarioRolDto);
        usuarioRol.UsuarioId = idUsuario;
        usuarioRol.RolId = idRol;
        var response= await _usuarioRol.Update(usuarioRol);
        if (response < 0)
        {
            return BadRequest();
        }

        return _mapper.Map<UsuarioRolDto>(usuarioRol);        
    }

    [HttpDelete("{idUsuario}/{idRol}")]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioRolDto>> Delete(int idUsuario, int idRol)
    {
        var usuarioRol = await _usuarioRol.GetByIdAsync (idUsuario, idRol);
        
        if (usuarioRol == null) {
            return NotFound();
        }

        var response = await _usuarioRol.Remove(usuarioRol);
        if (response < 0)
        {
            return BadRequest();
        }

        return Ok();
    }
}
