using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi;

[ApiController]
[Route("/api/v1/[controller]")]
[Authorize]
public class OrcamentosController : ControllerBase
{

    private readonly AppDbContext _context;
    private IMapper _mapper;

    public OrcamentosController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Orcamento>>> GetOrcamentos()
    {

        var orcamentos = await _context.Orcamentos.ToListAsync();
        return Ok(orcamentos);
    }

    [HttpPost]
    public async Task<ActionResult<Orcamento>> CreateOrcamentos([FromBody] CreateOrcamentoDto createOrcamentoDto)
    {
        Orcamento orcamentos = _mapper.Map<Orcamento>(createOrcamentoDto);
        _context.Orcamentos.Add(orcamentos);
        await _context.SaveChangesAsync();

        return Created("~/api/v1/orcamentos" + orcamentos.Id, orcamentos);

    }
}
