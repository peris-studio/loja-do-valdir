namespace LojaDoValdir.Models;
using LojaDoValdir.Enums;
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
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public static Cliente Inserir(string nome, string sobrenome, int idade, char sexo, DateOnly dataNascimento)
    {
        var novoCliente = new Cliente()
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Sobrenome = sobrenome,
            Idade = idade,
            Sexo = sexo,
            DataNascimento = dataNascimento,
            DataCriacao = DateTime.Now,
            Ativo = true
        };

        return novoCliente;
    }

    public static Cliente Atualizar(Cliente cliente, string nome, string sobrenome, int idade, char sexo, DateOnly dataNascimento)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo");
        }

        else
        {
            cliente.Nome = nome;
            cliente.Sobrenome = sobrenome;
            cliente.Idade = idade;
            cliente.Sexo = sexo;
            cliente.DataNascimento = dataNascimento;
            cliente.DataAtualizacao = DateTime.Now;

            return cliente;
        }
    }

    public static Cliente Remover(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo");
        }

        else
        {
            cliente.DataDelecao = DateTime.Now;
            cliente.Ativo = false;

            return cliente;
        }
    }

    public override string ToString() // estilização do retorno do cliente
    {
        string status = Ativo ? "Sim" : "Não";
        return $"Nome: {Nome} {Sobrenome} | Idade: {Idade} | Sexo: {Sexo} | Data de Nascimento: {DataNascimento} | Data de criação do cadastro: {DataCriacao} | Ativo: {status} ";
    }
}