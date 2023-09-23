using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos.Orcamento;
using WebApi.Models;
using WebApi.Services.Orcamento;

namespace WebApi;

[ApiController]
[Route("/api/v1/[controller]")]
[Authorize]
public class OrcamentosController : ControllerBase
{

    private readonly AppDbContext _context;
    private IMapper _mapper;

    private readonly IOrcamentoInterface _orcamentoInterface;

    public OrcamentosController(AppDbContext context, IMapper mapper, IOrcamentoInterface orcamentoInterface)
    {
        _context = context;
        _mapper = mapper;
        _orcamentoInterface = orcamentoInterface;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadOrcamentoDto>>> GetOrcamentos([FromQuery] int skip = 0, int take = 25)
    {
        // List<Orcamento> orcamentos = await _context.Orcamentos.Include(x => x.Produtos).ToListAsync();
        // var orcamentoDto = _mapper.Map<List<ReadOrcamentoDto>>(orcamentos);

        // return Ok(orcamentoDto);

        IEnumerable<Orcamento> orcamentos = await _orcamentoInterface.GetOrcamentos(skip, take);
        if (orcamentos != null)
        {
            var orcamentoDto = _mapper.Map<IEnumerable<ReadOrcamentoDto>>(orcamentos);
            return Ok(orcamentoDto);
        }
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadOrcamentoDto>> FindOrcamento(int id)
    {
        Orcamento orcamento = await _orcamentoInterface.FindOrcamento(id);
        if (orcamento != null)
        {
            var orcamentoDto = _mapper.Map<ReadOrcamentoDto>(orcamento);
            return Ok(orcamentoDto);
        }
        return NotFound();
    }


    [HttpPost]
    public async Task<ActionResult<Orcamento>> CreateOrcamentos([FromBody] CreateOrcamentoDto createOrcamentoDto)
    {

        Orcamento orcamento = _mapper.Map<Orcamento>(createOrcamentoDto);
        await _orcamentoInterface.CreateOrcamento(orcamento);
        return Created("~/api/v1/orcamentos" + orcamento.Id, orcamento);

    }
}
