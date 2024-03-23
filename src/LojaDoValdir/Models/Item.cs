namespace LojaDoValdir.Models;

using LojaDoValdir.Enums;

public class Item
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public TipoItem TipoItem { get; set; }
    public bool? ItemEmEstoque { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public Item Inserir(string nome, string descricao, double preco, TipoItem tipoItem, bool itemEmEstoque, int quantidade)
    {
        var novoItem = new Item()
        {
            Nome = nome,
            Descricao = descricao,
            TipoItem = tipoItem,
            Preco = preco,
            ItemEmEstoque = itemEmEstoque,
            Quantidade = quantidade,
            DataCriacao = DateTime.Now,
            Ativo = true,
        };
        return novoItem;
    }

    public Item Atualizar(Item item, string nome, string descricao, double preco, TipoItem tipoItem, int quantidade)
    {
        item.Nome = nome;
        item.Descricao = descricao;
        item.Preco = preco;
        item.TipoItem = tipoItem;
        item.Quantidade = quantidade;
        item.DataAtualizacao = DateTime.Now;
        item.Ativo = true;

        return item;
    }

    public Item Remover(Item item)
    {
        item.DataDelecao = DateTime.Now;
        item.Ativo = false;

        return item;
    }
}