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
    public bool? Ativo { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public Endereco Inserir(string logradouro, string numero, string bairro, string cidade, string uf)
    {
        var novoEndereco = new Endereco()
        {
            Logradouro = logradouro,
            Numero = numero,
            Bairro = bairro,
            Cidade = cidade,
            UF = uf,
            DataCriacao = DateTime.Now,
            Ativo = true
        };

        return novoEndereco;
    }
    public override string ToString()
    {
        return $"Logradouro: {Logradouro}, {Numero} - {Bairro}, {Cidade} - {UF} | Data de criação do cadastro: {DataCriacao} | Status: {Ativo}";
    }
}