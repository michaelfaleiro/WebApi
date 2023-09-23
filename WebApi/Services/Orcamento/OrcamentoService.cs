

using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Services.Orcamento
{

    public class OrcamentoService : IOrcamentoInterface
    {
        private readonly AppDbContext _context;

        public OrcamentoService(AppDbContext context)
        {
            _context = context;
        }

        async Task<Models.Orcamento> IOrcamentoInterface.CreateOrcamento(Models.Orcamento orcamento)
        {
            await _context.Orcamentos.AddAsync(orcamento);
            await _context.SaveChangesAsync();
            return orcamento;
        }

        async Task<Models.Orcamento> IOrcamentoInterface.FindOrcamento(int id)
        {
            return await _context.Orcamentos.Include(i => i.Produtos).FirstOrDefaultAsync(x => x.Id == id);
        }

        async Task<IEnumerable<Models.Orcamento>> IOrcamentoInterface.GetOrcamentos(int skip, int take)
        {
            return await _context.Orcamentos.Include(x => x.Produtos).AsNoTracking().Skip(skip).Take(take).ToListAsync();
        }
    }
}