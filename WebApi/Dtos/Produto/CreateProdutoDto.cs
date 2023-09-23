namespace WebApi;

public class CreateProdutoDto
{
    public string Sku { get; set; }
    public string Nome { get; set; }

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    public int OrcamentosId { get; set; }
}
