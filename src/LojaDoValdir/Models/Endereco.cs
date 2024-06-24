namespace LojaDoValdir.Models;

public class Endereco
{
    public Guid Id { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public static Endereco Inserir(string logradouro, string numero, string bairro, string cidade, string uf, Guid clienteId)
    {
        var novoEndereco = new Endereco()
        {
            Id = Guid.NewGuid(),
            Logradouro = logradouro,
            Numero = numero,
            Bairro = bairro,
            Cidade = cidade,
            UF = uf,
            ClienteId = clienteId,
            DataCriacao = DateTime.Now,
            Ativo = true
        };

        return novoEndereco;
    }

    public static Endereco Atualizar(Endereco endereco, string logradouro, string numero, string bairro, string cidade, string uf)
    {
        if (endereco == null)
        {
            throw new ArgumentNullException(nameof(endereco), "O endereço não pode ser nulo");
        }

        else
        {
            endereco.Logradouro = logradouro;
            endereco.Numero = numero;
            endereco.Bairro = bairro;
            endereco.Cidade = cidade;
            endereco.UF = uf;
            endereco.DataAtualizacao = DateTime.Now;

            return endereco;
        }
    }

    public static Endereco Remover(Endereco endereco)
    {
        if (endereco == null)
        {
            throw new ArgumentNullException(nameof(endereco), "O endereço não pode ser nulo");
        }

        else
        {
            endereco.DataDelecao = DateTime.Now;
            endereco.Ativo = false;

            return endereco;
        }
    }

    public override string ToString()
    {
        string status = Ativo ? "Sim" : "Não";
        return $"Logradouro: {Logradouro}, {Numero} - {Bairro}, {Cidade} - {UF} | Data de criação do cadastro: {DataCriacao} | Ativo: {status}";
    }
}