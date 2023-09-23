using AutoMapper;
using WebApi.Dtos.Orcamento;
using WebApi.Models;

namespace WebApi;

public class OrcamentoProfile : Profile
{
    public OrcamentoProfile()
    {
        CreateMap<CreateOrcamentoDto, Orcamento>();
        CreateMap<Orcamento, ReadOrcamentoDto>()
            .ForMember(orcamentoDto => orcamentoDto.Produtos,
            opt => opt.MapFrom(orcamento => orcamento.Produtos
            ));
    }
}
