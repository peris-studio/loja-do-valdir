namespace LojaDoValdir.Models;

using LojaDoValdir.Enums;

public class PedidoItem
{
    public Guid Id { get; set; }
    public double Preco { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

    public PedidoItem Inserir(double preco, Guid pedidoId, Guid itemId)
    {
        var novoPedidoItem = new PedidoItem()
        {
            Preco = preco,
            PedidoId = pedidoId,
            ItemId = itemId,
            DataCriacao = DateTime.Now,
            Ativo = true
        };
        return novoPedidoItem;
    }

    public PedidoItem Atualizar(PedidoItem pedidoItem, double preco)
    {
        pedidoItem.Preco = preco;
        pedidoItem.DataAtualizacao = DateTime.Now;
        pedidoItem.Ativo = true;

        return pedidoItem;
    }

    public PedidoItem Remover(PedidoItem pedidoItem)
    {
        pedidoItem.Ativo = false;
        pedidoItem.DataDelecao = DateTime.Now;

        return pedidoItem;
    }
}