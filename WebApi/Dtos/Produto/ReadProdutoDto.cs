﻿namespace WebApi.Dtos.Produto;

public class ReadProdutoDto
{
    public string Sku { get; set; }
    public string Nome { get; set; }

    public int Quantidade { get; set; }

    public double Preco { get; set; }

    public int OrcamentoId { get; set; }
}
