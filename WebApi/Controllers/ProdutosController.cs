using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos.Produto;
using WebApi.Models;

namespace WebApi;

[ApiController]
[Route("api/v1/")]

public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProdutosController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
    }

    [HttpPost("orcamentos/{orcamentoId}/produtos")]
    public async Task<IActionResult> CreateProduto( int orcamentoId, [FromBody] Produto produtoNovo)
    {


        try
        {
            Console.WriteLine(produtoNovo);

            produtoNovo.OrcamentoId = orcamentoId;
            
            _context.Produtos.Add(produtoNovo);
            
            await _context.SaveChangesAsync();

            return Ok(produtoNovo);
        } catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }

    }


    [HttpGet("produtos")]

    public async Task<ActionResult<List<Produto>>> GetProdutos()
    {
        List<Produto> produtos = await _context.Produtos.AsNoTracking().ToListAsync();
        
        var readProdutosDto = _mapper.Map<List<ReadProdutoDto>>(produtos);
        return Ok(readProdutosDto);
    }
     
}
