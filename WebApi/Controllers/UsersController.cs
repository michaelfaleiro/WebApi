using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using WebApi.Dtos.Users;
using WebApi.Models;
using WebApi.Services.Users;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]

public class UsersController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly IUserInteface _userInteface;

    public UsersController(IMapper mapper, IUserInteface userInteface)
    {
        _mapper = mapper ?? throw new ArgumentNullException();
        _userInteface = userInteface;
    }

    [HttpPost]

    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        UsersModel user = _mapper.Map<UsersModel>(userDto);
        var password = userDto.Password;
        user.Password = PasswordHasher.Hash(password);
        await _userInteface.CreateUser(user);
        return Created("~/v1/api/users/" + user.Id, null);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsersModel>>> GetUsers([FromQuery] int skip = 0, int take = 25)
    {
        IEnumerable<UsersModel> users = await _userInteface.GetUsers(skip, take);
        if (users != null)
        {
            var userDto = _mapper.Map<IEnumerable<ReadUsersDto>>(users);
            return Ok(userDto);
        }
        return NotFound("Sem dados");
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<UsersModel>> FindUser(int id)
    {
        UsersModel user = await _userInteface.FindUser(id);
        if (user != null)
        {
            ReadUsersDto readUsersDto = _mapper.Map<ReadUsersDto>(user);
            return Ok(readUsersDto);
        }
        return NotFound("Não encontrado");
    }

   

}


