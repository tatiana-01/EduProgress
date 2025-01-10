using EduProgressApi.Dtos;
using EduProgressApi.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;

public class UsuarioRolController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioRolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
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
        var usuariosRoles = await _unitOfWork.UsuarioRoles.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);

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
        var usuarioRol = await _unitOfWork.UsuarioRoles.GetByIdAsync(idUsuario, idRol);

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
        _unitOfWork.UsuarioRoles.Add(usuarioRol);
        await _unitOfWork.SaveAsync();

        if (usuarioRol == null) {
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
        _unitOfWork.UsuarioRoles.Update(usuarioRol);
        await _unitOfWork.SaveAsync();

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
        var usuarioRol = await _unitOfWork.UsuarioRoles.GetByIdAsync (idUsuario, idRol);
        
        if (usuarioRol == null) {
            return NotFound();
        }

        _unitOfWork.UsuarioRoles.Remove(usuarioRol);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
