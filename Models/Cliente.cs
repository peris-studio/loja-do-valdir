namespace LojaDoValdir;

public class Cliente
{
    public Guid Id { get; set; }
    /* 

    string hexadecimal de 32 caracteres, agrupados em cinco seções, separadas por hifens

    ex: f47ac10b-58cc-4372-a567-0e02b2c3d479

    */
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
    public DateOnly DataNascimento { get; set; } // DateOnly é uma nova estrutura apropriada para representar somente datas, independente de horário
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public Cliente Inserir(string nome, string sobrenome, int idade, char sexo, DateOnly dataNascimento)
    {
        var novoCliente = new Cliente()
        {
            Nome = nome,
            Sobrenome = sobrenome,
            Idade = idade,
            Sexo = sexo,
            DataNascimento = dataNascimento,
            DataCriacao = DateOnly.FromDateTime(DateTime.Now), // DateTime não possui o método ToDateOnly() padrão, para converter precisa ser nessa estrutura;
            Ativo = true
        };

        return novoCliente;
    }
    public override string ToString() // estilização do retorno do cliente
    {
        return $"Nome: {Nome} {Sobrenome} | Idade: {Idade} | Sexo: {Sexo} | Data de Nascimento: {DataNascimento} | Data de criação do cadastro: {DataCriacao} | Status: {Ativo}";
    }
}