namespace LojaDoValdir.Models;

public class ItemDesconto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double PrecoComum { get; set; }
    public double PorcentagemDesconto { get; set; }
    public double PrecoDescontado { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

    public static ItemDesconto Inserir(string nome, double precoComum, double porcentagemDesconto, double precoDescontado, DateTime dataInicio, DateTime dataTermino, Guid itemId)
    {
        var novoDesconto = new ItemDesconto()
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            PrecoComum = precoComum,
            PorcentagemDesconto = porcentagemDesconto,
            PrecoDescontado = precoDescontado,
            DataCriacao = DateTime.Now,
            DataInicio = dataInicio,
            DataTermino = dataTermino,
            ItemId = itemId,
            Ativo = true
        };
        return novoDesconto;
    }

    public static ItemDesconto Atualizar(ItemDesconto desconto, string nome, double precoComum, double porcentagemDesconto, double precoDescontado, DateTime dataInicio, DateTime dataTermino)
    {
        if (desconto == null)
        {
            throw new ArgumentNullException(nameof(desconto), "O desconto não pode ser nulo");
        }

        else
        {
            desconto.Nome = nome;
            desconto.PrecoComum = precoComum;
            desconto.PorcentagemDesconto = porcentagemDesconto;
            desconto.PrecoDescontado = precoDescontado;
            desconto.DataInicio = dataInicio;
            desconto.DataTermino = dataTermino;
            desconto.DataAtualizacao = DateTime.Now;

            return desconto;
        }
    }

    public static ItemDesconto Remover(ItemDesconto desconto)
    {
        if (desconto == null)
        {
            throw new ArgumentNullException(nameof(desconto), "O desconto não pode ser nulo");
        }

        else
        {
            desconto.DataDelecao = DateTime.Now;
            desconto.Ativo = false;

            return desconto;
        }
    }
    public override string ToString() // estilização do retorno pro cliente
    {
        return $"Item {Nome} de R${PrecoComum} com desconto de {PorcentagemDesconto}%, por {PrecoDescontado}! - Data de Criação: {DataCriacao}| Data de Início: {DataInicio} | Data de Término: {DataTermino} | Ativo: {Ativo}";
    }
}