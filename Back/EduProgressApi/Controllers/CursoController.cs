
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;
public class CursoController : BaseApiController
{
    private readonly ICurso _cursos;
    private readonly IMapper _mapper;
    public CursoController(ICurso cursos, IMapper mapper)
    {
        _mapper = mapper;
        _cursos = cursos;
    }


    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CursoGetByUserRolDto>>> GetCursosByRolAndUser(string user, string rol)
    {
        var cursos = await _cursos.GetCursosByRolAndUserAsync(user,rol);
        if (cursos == null)
        {
            return BadRequest();
        }
        if (cursos.Count() <= 0)
        {
            return NotFound();
        }
        
        return Ok(cursos);
    }

    [HttpGet("{id}")]
    [Authorize]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Curso>> GetById(int id)
    {
        var rol = await _cursos.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return _mapper.Map<Curso>(rol);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CursoDto>> Post(CursoDto cursoDto)
    {
        var curso = _mapper.Map<Curso>(cursoDto);
        var response = await _cursos.Add(curso);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<CursoDto>(curso);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Curso>> Put(int id, [FromBody] Curso rolDto)
    {
        if (rolDto == null)
        {
            return NotFound();
        }
        var rol = _mapper.Map<Curso>(rolDto);
        var response = await _cursos.Update(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return _mapper.Map<Curso>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Curso>> Delete(int id)
    {
        var rol = await _cursos.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        var response = await _cursos.Remove(rol);
        if (response < 0)
        {
            return BadRequest();
        }
        return NoContent();
    }
}