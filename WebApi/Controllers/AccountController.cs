using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;


namespace WebApi.Controllers;

[ApiController]
[Route("/api/v1/account/")]
public class AccountController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly AppDbContext _context;

    public AccountController(TokenService tokenService, AppDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UsersModel user)
    {
        var userLogin = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == user.Email);
        if (userLogin == null) return Unauthorized("Email ou Senha Inválidos");

        if (!PasswordHasher.Verify(userLogin.Password, user.Password))
        {
            return Unauthorized("Email ou Senha Inválidos!");
        }

        var token = _tokenService.GenerateToken(user);

        return Ok(token);
    }



}

