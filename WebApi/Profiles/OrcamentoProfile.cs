using AutoMapper;
using WebApi.Models;

namespace WebApi;

public class OrcamentoProfile : Profile
{
    public OrcamentoProfile()
    {
        CreateMap<CreateOrcamentoDto, Orcamento>();
    }
}
