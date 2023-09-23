using WebApi.Dtos.Produto;

namespace WebApi.Dtos.Orcamento;

public class ReadOrcamentoDto
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }

    public string Telefone { get; set; }

    public string Veiculo { get; set; }

    public string Placa { get; set; }

    public string Chassis { get; set; }
    public string Status { get; set; }

    public List<ReadProdutoDto> Produtos { get; set; }

}
