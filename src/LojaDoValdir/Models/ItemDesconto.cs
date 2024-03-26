namespace LojaDoValdir.Models;

public class ItemDesconto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

    public ItemDesconto Inserir(string nome, double preco, DateTime dataInicio, DateTime dataTermino, Guid itemId)
    {
        var novoDesconto = new ItemDesconto()
        {
            Nome = nome,
            Preco = preco,
            DataCriacao = DateTime.Now,
            DataInicio = dataInicio,
            DataTermino = dataTermino,
            ItemId = itemId,
            Ativo = true
        };
        return novoDesconto;
    }

    public ItemDesconto Atualizar(ItemDesconto itemDesconto, string nome, double preco, DateTime dataInicio, DateTime dataTermino)
    {
        itemDesconto.Nome = nome;
        itemDesconto.Preco = preco;
        itemDesconto.DataInicio = dataInicio;
        itemDesconto.DataTermino = dataTermino;
        itemDesconto.DataAtualizacao = DateTime.Now;

        return itemDesconto;
    }

    public ItemDesconto Remover(ItemDesconto itemDesconto)
    {
        itemDesconto.DataDelecao = DateTime.Now;
        itemDesconto.Ativo = false;
        
        return itemDesconto;
    }
}