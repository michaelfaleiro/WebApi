
using WebApi.Models;

namespace WebApi.Services.Orcamento;

public interface IOrcamentoInterface
{
    Task<Models.Orcamento> CreateOrcamento(Models.Orcamento orcamento);

    Task<IEnumerable<Models.Orcamento>> GetOrcamentos(int take, int skip);

    Task<Models.Orcamento> FindOrcamento(int id);

}