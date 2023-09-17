using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services.Users;

public class UserService : IUserInteface
{
    private readonly AppDbContext _context;


    public UserService(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UsersModel> CreateUser(UsersModel user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UsersModel> FindUser(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<UsersModel>> GetUsers(int skip, int take)
    {
        return await _context.Users.AsNoTracking().Skip(skip).Take(take).ToListAsync();
    }


}