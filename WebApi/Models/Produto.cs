using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models;

namespace WebApi;

public class Produto
{
    [Key]
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Nome { get; set; }

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    [ForeignKey("OrcamentoId")]
    public int OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? UpdateDate { get; set; } = DateTime.UtcNow;
}
