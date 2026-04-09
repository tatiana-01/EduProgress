using EduProgressApi.Helpers;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;

namespace EduProgressApi.Controllers;
public class RolController : BaseApiController
{
    private readonly IRol _roles;
    private readonly IMapper _mapper;
    public RolController(IRol roles, IMapper mapper)
    {
        _mapper = mapper;
        _roles = roles;
    }

   /*  [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<RolDto>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RolDto>>(roles);
    } */

    [HttpGet]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<RolGetAllDto>>> GetAll([FromQuery] Params rolParams)
    {
        var roles = await _roles.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstTipoPersonaDto = _mapper.Map<List<RolGetAllDto>>(roles.registros);
        return new Pager<RolGetAllDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolGetAllDto>> GetById(int id)
    {
        var rol = await _roles.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        return _mapper.Map<RolGetAllDto>(rol);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Post(RolPostDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);
        var response=await _roles.Add(rol);
        if (response<0) {
            return BadRequest();
        }
        return _mapper.Map<RolDto>(rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }
        var rol = _mapper.Map<Rol>(rolDto);
        var response = await _roles.Update(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<RolDto>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Delete(int id)
    {
        var rol = await _roles.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        var response = await _roles.Remove(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return NoContent();
    }
}