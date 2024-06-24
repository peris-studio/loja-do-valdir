namespace LojaDoValdir.Models;

using LojaDoValdir.Enums;

public class PedidoItem
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

    public static PedidoItem Inserir(string nome, string descricao, double preco, Guid pedidoId, Guid itemId)
    {
        var novoPedidoItem = new PedidoItem()
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            PedidoId = pedidoId,
            ItemId = itemId,
            DataCriacao = DateTime.Now,
            Ativo = true
        };
        return novoPedidoItem;
    }

    public static PedidoItem Atualizar(PedidoItem pedidoItem, string nome, string descricao, double preco)
    {
        if (pedidoItem == null)
        {
            throw new ArgumentNullException(nameof(pedidoItem), "O pedido do item não pode ser nulo");
        }

        else
        {
            pedidoItem.Nome = nome;
            pedidoItem.Descricao = descricao;
            pedidoItem.Preco = preco;
            pedidoItem.DataAtualizacao = DateTime.Now;

            return pedidoItem;
        }
    }

    public static PedidoItem Remover(PedidoItem pedidoItem)
    {
        if (pedidoItem == null)
        {
            throw new ArgumentNullException(nameof(pedidoItem), "O pedido do item não pode ser nulo");
        }

        else
        {
            pedidoItem.Ativo = false;
            pedidoItem.DataDelecao = DateTime.Now;

            return pedidoItem;
        }
    }

    public override string ToString()
    {
        return $"Pedido {PedidoId} - {Nome}, no valor total de R${Preco}";
    }
}