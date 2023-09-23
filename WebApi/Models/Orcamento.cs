using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Orcamento
{
    [Key]
    public int Id { get; set; }

    public string NomeCliente { get; set; }

    public string Telefone { get; set; }

    public string Veiculo { get; set; }

    public string Placa { get; set; }

    public string Chassis { get; set; }
    public string Status { get; set; }

    public List<Produto> Produtos { get; set; }
    public double ValorTotal { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }

}