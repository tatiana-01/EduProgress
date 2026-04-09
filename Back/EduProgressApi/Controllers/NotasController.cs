
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;
public class NotasController : BaseApiController
{
    private readonly INotas _notas;
    private readonly IMapper _mapper;
    public NotasController(INotas notas, IMapper mapper)
    {
        _mapper = mapper;
        _notas = notas;
    }


    [HttpGet("NotassBycouseAndUser")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<NotasStuCursoDto>>> GetNotassBycouseAndUser(string user, string curso)
    {
        var notas = await _notas.GetNotasByCursoAndUserAsync(user, curso);
        if (notas == null)
        {
            return BadRequest();
        }
        if (notas.Count() <= 0)
        {
            return NotFound();
        }

        return Ok(notas);
    }

    [HttpGet("{id}")]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Nota>> GetById(int id)
    {
        var rol = await _notas.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return _mapper.Map<Nota>(rol);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Nota>> Post(Nota cursoDto)
    {
        var curso = _mapper.Map<Nota>(cursoDto);
        var response = await _notas.Add(curso);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Nota>(curso);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Nota>> Put(int id, [FromBody] Nota rolDto)
    {
        if (rolDto == null)
        {
            return NotFound();
        }
        var rol = _mapper.Map<Nota>(rolDto);
        var response = await _notas.Update(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Nota>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Nota>> Delete(int id)
    {
        var rol = await _notas.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        var response = await _notas.Remove(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return NoContent();
    }
}