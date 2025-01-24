
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;
public class SeguimientoController : BaseApiController
{
    private readonly ISeguimiento _seguimiento;
    private readonly IMapper _mapper;
    public SeguimientoController(ISeguimiento seguimiento, IMapper mapper)
    {
        _mapper = mapper;
        _seguimiento = seguimiento;
    }


    

    /*[HttpGet("{id}")]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Seguimiento>> GetById(int id)
    {
        var rol = await _seguimiento.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return _mapper.Map<Seguimiento>(rol);
    }*/

    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SeguimientoPostDto>> Post(SeguimientoPostDto segDto)
    {
        var response = await _seguimiento.AddComByUser(segDto.USer,segDto.ComId,segDto.Com);
        if (response < 0)
        {
            return BadRequest();
        }
        return Ok();
    }

   /* [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Seguimiento>> Put(int id, [FromBody] Seguimiento rolDto)
    {
        if (rolDto == null)
        {
            return NotFound();
        }
        var rol = _mapper.Map<Seguimiento>(rolDto);
        var response = await _seguimiento.Update(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Seguimiento>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Seguimiento>> Delete(int id)
    {
        var rol = await _seguimiento.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        var response = await _seguimiento.Remove(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return NoContent();
    }*/
}