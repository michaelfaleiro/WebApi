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


    async Task<ServiceResponse<UsersModel>> IUserInteface.CreateUser(UsersModel users)
    {
        ServiceResponse<UsersModel> serviceResponse = null;
        try
        {
            if (users == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informar Dados";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            
            
        } catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    async Task<ServiceResponse<List<UsersModel>>> IUserInteface.GetUsers(int take, int skip)
    {

        ServiceResponse<List<UsersModel>> serviceResponse = new();

        try
        {
            serviceResponse.Dados = await _context.Users.AsNoTracking().ToListAsync();
            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum dado encontrado";
            }
        }  catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;

       

    }
}
