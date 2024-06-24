namespace LojaDoValdir.Models;

using LojaDoValdir.Enums;

public class Item
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Peso { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public TipoItem TipoItem { get; set; }
    public bool ItemEmEstoque { get; set; }
    public int QuantidadeUnidade { get; set; }
    public int QuantidadeFardo { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public static Item Inserir(string nome, string peso, string descricao, double preco, TipoItem tipoItem, bool itemEmEstoque, int quantidadeUnidade, int quantidadeFardo)
    {
        var novoItem = new Item()
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Peso = peso,
            Descricao = descricao,
            Preco = preco,
            TipoItem = tipoItem,
            ItemEmEstoque = itemEmEstoque,
            QuantidadeUnidade = quantidadeUnidade,
            QuantidadeFardo = quantidadeFardo,
            DataCriacao = DateTime.Now,
            Ativo = true,
        };
        return novoItem;
    }

    public static Item Atualizar(Item item, string nome, string peso, string descricao, double preco, TipoItem tipoItem, bool itemEmEstoque, int quantidadeUnidade, int quantidadeFardo)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "O item não pode ser nulo");
        }

        else
        {
            item.Nome = nome;
            item.Peso = peso;
            item.Descricao = descricao;
            item.Preco = preco;
            item.TipoItem = tipoItem;
            item.ItemEmEstoque = itemEmEstoque;
            item.QuantidadeUnidade = quantidadeUnidade;
            item.QuantidadeFardo = quantidadeFardo;
            item.DataAtualizacao = DateTime.Now;

            return item;
        }
    }

    public static Item Remover(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "O item não pode ser nulo");
        }

        else
        {
            item.DataDelecao = DateTime.Now;
            item.Ativo = false;

            return item;
        }
    }

    public override string ToString() // estilização do retorno do cliente
    {
        return $"Mercadoria: {Nome} | Peso: {Peso} | Descrição: {Descricao} | R${Preco} | Variedade: {TipoItem} | Quantidade Disponível (unidade): {QuantidadeUnidade} | Fardo: {QuantidadeFardo} |Ativo: {Ativo}";
    }
}