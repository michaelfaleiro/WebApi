using WebApi.Models;

namespace WebApi.Services.Users;

public interface IUserInteface
{
    Task<ServiceResponse<UsersModel>> CreateUser(UsersModel users);
    Task<ServiceResponse<List<UsersModel>>> GetUsers(int take, int skip);
}   
