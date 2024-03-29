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

    public Contato Inserir(string codigoDDI, string codigoDDD, string codigoTelefone, bool telefonePrincipal)
    {
        var novoContato = new Contato()
        {
            CodigoDDI = codigoDDI,
            CodigoDDD = codigoDDD,
            CodigoTelefone = codigoTelefone,
            TelefonePrincipal = true,
            DataCriacao = DateTime.Now,
            Ativo = true
        };

        return novoContato;
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