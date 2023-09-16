using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos.Users;
using WebApi.Models;
using WebApi.Services.Users;

namespace WebApi.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
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
        await _userInteface.CreateUser(user);
        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] int skip = 0, int take = 25)
    {
        var users = await _userInteface.GetUsers(skip, take);
        return Ok(users); ;
    }                                                                                           
}
