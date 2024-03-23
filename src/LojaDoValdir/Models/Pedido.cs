namespace LojaDoValdir.Models;
using Enums.Models;

public class Pedido
{
    public Guid Id { get; set; }
    public StatusPedido Status { get; set; }
    public DateOnly PrevisaoEntrega { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool? Ativo { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public Guid EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
    public Guid ContatoId { get; set; }
    public Contato Contato { get; set; }


    public Pedido Inserir(Guid clienteId, Guid enderecoId, Guid contatoId, DateOnly previsaoEntrega)
    {
        var novoPedido = new Pedido()
        {
            ClienteId = clienteId,
            EnderecoId = enderecoId,
            ContatoId = contatoId,
            PrevisaoEntrega = previsaoEntrega,
            Status = StatusPedido.Criado,
            DataCriacao = DateTime.Now,
            Ativo = true
        };
        return novoPedido;
    }

    public Pedido Atualizar(Pedido pedido, Guid enderecoId, Guid contatoId, StatusPedido status, DateOnly previsaoEntrega)
    {
        pedido.EnderecoId = enderecoId;
        pedido.ContatoId = contatoId;
        pedido.Status = status;
        pedido.DataAtualizacao = DateTime.Now;
        return pedido;
    }

    public Pedido Remover(Pedido pedido, Guid id)
    {
        pedido.DataDelecao = DateTime.Now;
        pedido.Ativo = false;
        pedido.Status = StatusPedido.Cancelado;
        return pedido;
    }

    public override string ToString() // estilização do retorno do cliente
    {
        return $"Cliente: {ClienteId} | Endereço: {EnderecoId} | Contato: {ContatoId} | Previsão de entrega: {PrevisaoEntrega} | Data de criação: {DataCriacao} | Status: Ativo";
    }
}