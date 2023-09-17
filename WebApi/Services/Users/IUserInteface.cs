using WebApi.Models;

namespace WebApi.Services.Users;

public interface IUserInteface
{
    Task<UsersModel> CreateUser(UsersModel users);
    Task<IEnumerable<UsersModel>> GetUsers(int take, int skip);
    Task<UsersModel> FindUser(int id);
}
