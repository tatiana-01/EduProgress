using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using EduProgressApi.Dtos;
using EduProgressApi.Helpers;
using EduProgressApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduProgressApi.Controllers;
public class UsuarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userService=userService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken); //activar la cookie con el refreshToken
        return Ok(result);
    }

    [HttpPost("addrol")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddRolAsync(AddRolDto model)
    {
        var result= await _userService.AddRolAsync(model);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

   /*  [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UsuarioDto>>> GetTodos()
    {
        var usuarios = await _unitOfWork.Usuarios.GetAllAsync();
        return _mapper.Map<List<UsuarioDto>>(usuarios);
    }
 */

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioGetAllDto>> Get(int id)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if (usuario == null) {
            return NotFound();
        }
        return _mapper.Map<UsuarioGetAllDto>(usuario);
    }

    [HttpGet("username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UsuarioGetAllDto> GetByUsername(string username)
    {
        var usuarioXrol =  _unitOfWork.Usuarios.Find(p=>p.Username==username).First();
        if (usuarioXrol == null) {
            return NotFound();
        }
        return _mapper.Map<UsuarioGetAllDto>(usuarioXrol);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UsuarioGetAllDto>>> GetTodoPagina([FromQuery] Params usuarioParams)
    {
        var usuariosXroles = await _unitOfWork.Usuarios.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
        var lstUsuarioGetAllDto = _mapper.Map<List<UsuarioGetAllDto>>(usuariosXroles.registros);
        return new Pager<UsuarioGetAllDto>(lstUsuarioGetAllDto, usuariosXroles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody] UsuarioDto usuarioDto)
    {
        if (usuarioDto == null) {
            return NotFound();
        }
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        usuario.Id = id;
        var editUsuarioRol = await _userService.EditUserAsync(usuario);
        return _mapper.Map<UsuarioDto>(editUsuarioRol);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> DeleteUsuario(int id)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if(usuario == null) {
            return NotFound();
        }
        _unitOfWork.Usuarios.Remove(usuario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}