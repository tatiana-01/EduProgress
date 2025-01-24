
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;
public class ComportamientoController : BaseApiController
{
    private readonly IComportamiento _comportamiento;
    private readonly IMapper _mapper;
    public ComportamientoController(IComportamiento comportamiento, IMapper mapper)
    {
        _mapper = mapper;
        _comportamiento = comportamiento;
    }


    [HttpGet("ComportamientosBycouseAndUser")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ComByUserCourseDto>>> GetComportamientosBycouseAndUser(string user, string curso)
    {
        var comportamiento = await _comportamiento.GetComsByCursoAndUserAsync(user, curso);
        if (comportamiento == null)
        {
            return BadRequest();
        }
        if (comportamiento.Count() <= 0)
        {
            return NotFound();
        }

        return Ok(comportamiento);
    }

    [HttpGet("{id}")]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Comportamiento>> GetById(int id)
    {
        var rol = await _comportamiento.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return _mapper.Map<Comportamiento>(rol);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Comportamiento>> Post(Comportamiento comportamientoDto)
    {
        var comportamiento = _mapper.Map<Comportamiento>(comportamientoDto);
        var response = await _comportamiento.Add(comportamiento);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Comportamiento>(comportamiento);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Comportamiento>> Put(int id, [FromBody] Comportamiento rolDto)
    {
        if (rolDto == null)
        {
            return NotFound();
        }
        var rol = _mapper.Map<Comportamiento>(rolDto);
        var response = await _comportamiento.Update(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Comportamiento>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Comportamiento>> Delete(int id)
    {
        var rol = await _comportamiento.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        var response = await _comportamiento.Remove(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return NoContent();
    }
}