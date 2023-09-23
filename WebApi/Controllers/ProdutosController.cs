using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi;

[ApiController]
[Route("api/v1/")]
[Authorize]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    [HttpPost("orcamentos/{orcamentoId}/produtos")]
    public async Task<IActionResult> CreateProduto( int orcamentoId, [FromBody] Produto produto)
    {


        try
        {
            
            var orcamento = await _context.Orcamentos.FirstOrDefaultAsync(x => x.Id == orcamentoId);
            
            if (orcamento == null)
            {
                return NotFound("Orcamento não Encontrado");
            }

            if (produto == null)
            {
                return BadRequest("Dados inválidos");
            }

            produto.OrcamentoId = orcamentoId;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        } catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }

    }
}
