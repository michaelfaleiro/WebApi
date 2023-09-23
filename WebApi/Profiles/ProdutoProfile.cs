using AutoMapper;
using WebApi.Dtos.Produto;

namespace WebApi.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>();
    }
}
