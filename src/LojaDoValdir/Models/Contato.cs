namespace LojaDoValdir.Models;

public class Contato
{
    public Guid Id { get; set; }
    public string CodigoDDI { get; set; }
    public string CodigoDDD { get; set; }
    public string CodigoTelefone { get; set; }
    public bool TelefonePrincipal { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public static Contato Inserir(string codigoDDI, string codigoDDD, string codigoTelefone, bool telefonePrincipal, Guid clienteId)
    {
        var novoContato = new Contato()
        {
            Id = Guid.NewGuid(),
            CodigoDDI = codigoDDI,
            CodigoDDD = codigoDDD,
            CodigoTelefone = codigoTelefone,
            TelefonePrincipal = telefonePrincipal,
            ClienteId = clienteId,
            DataCriacao = DateTime.Now,
            Ativo = true
        };

        return novoContato;
    }

    public static Contato Atualizar(Contato contato, string codigoDDI, string codigoDDD, string codigoTelefone, bool telefonePrincipal)
    {
        if (contato == null)
        {
            throw new ArgumentNullException(nameof(contato), "O contato não pode ser nulo");
        }
        else
        {
            contato.CodigoDDI = codigoDDI;
            contato.CodigoDDD = codigoDDD;
            contato.CodigoTelefone = codigoTelefone;
            contato.TelefonePrincipal = telefonePrincipal;
            contato.DataAtualizacao = DateTime.Now;

            return contato;
        }
    }

    public static Contato Remover(Contato contato)
    {
        if (contato == null)
        {
            throw new ArgumentNullException(nameof(contato), "O contato não pode ser nulo");
        }
        else
        {
            contato.DataDelecao = DateTime.Now;
            contato.Ativo = false;

            return contato;
        }
    }

    // converter resposta do usuário para bool
    public static bool StringParaBool(string telefonePrincipal)
    {
        return telefonePrincipal.ToLower() == "sim";
    }

    public override string ToString()
    {
        string contatoPrincipal = TelefonePrincipal ? "Sim".ToLower() : "Não".ToLower();
        string status = Ativo ? "Sim" : "Não";
        return $"DDI: {CodigoDDI} | DDD: {CodigoDDD} | Telefone/Celular: {CodigoTelefone} | Telefone/Celular principal? {contatoPrincipal} | Data de criação de cadastro: {DataCriacao} | Ativo: {status}";
    }
}