using AutoMapper;
using WebApi.Dtos.Users;
using WebApi.Models;

namespace WebApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, UsersModel>();
        CreateMap<UsersModel, ReadUsersDto>();
    }
}
