using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<UsersModel> CreateUser(UsersModel users)
    {
        await _context.Users.AddAsync(users);
        await _context.SaveChangesAsync();
        return users;
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