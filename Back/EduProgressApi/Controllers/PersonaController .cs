
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;
public class PersonaController : BaseApiController
{
    private readonly IPersona _personas;
    private readonly IMapper _mapper;
    public PersonaController(IPersona personas, IMapper mapper)
    {
        _mapper = mapper;
        _personas = personas;
    }


    [HttpGet]
    [Authorize(Roles = "Administrador,Profesor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CursoDto>>> GetPersonasByRolAndUser(string curso)
    {
        var personas = await _personas.GetStudentsByCourse(curso);
        if (personas == null)
        {
            return BadRequest();
        }
        if (personas.Count() <= 0)
        {
            return NotFound();
        }
        
        return Ok(personas);
    }

    [HttpGet("{id}")]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Persona>> GetById(int id)
    {
        var rol = await _personas.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return _mapper.Map<Persona>(rol);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Persona>> Post(Persona cursoDto)
    {
        var curso = _mapper.Map<Persona>(cursoDto);
        var response = await _personas.Add(curso);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Persona>(curso);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Persona>> Put(int id, [FromBody] Persona rolDto)
    {
        if (rolDto == null)
        {
            return NotFound();
        }
        var rol = _mapper.Map<Persona>(rolDto);
        var response = await _personas.Update(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Persona>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Persona>> Delete(int id)
    {
        var rol = await _personas.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        var response = await _personas.Remove(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return NoContent();
    }
}