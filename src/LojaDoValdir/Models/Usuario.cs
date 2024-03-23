namespace LojaDoValdir.Models;

using LojaDoValdir.Enums;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public Usuario Inserir(string nome, string email, string senha, TipoUsuario tipoUsuario)
    {
        var novoUsuario = new Usuario()
        {
            Nome = nome,
            Email = email,
            Senha = senha,
            TipoUsuario = tipoUsuario,
            DataCriacao = DateTime.Now,
            Ativo = true
        };
        return novoUsuario;
    }

    public Usuario Atualizar(Usuario usuario, string nome, string email, string senha, TipoUsuario tipoUsuario)
    {
        usuario.Nome = nome;
        usuario.Email = email;
        usuario.Senha = senha;
        usuario.TipoUsuario = tipoUsuario;
        usuario.DataAtualizacao = DateTime.Now;
        usuario.Ativo = true;

        return usuario;
    }

    public Usuario Remover(Usuario usuario)
    {
        usuario.DataDelecao = DateTime.Now;
        usuario.Ativo = false;

        return usuario;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | E-mail: {Email} | Senha: {"*".PadLeft(Senha.Length, '*')} | Tipo: {TipoUsuario} | Ativo: {Ativo}";
    }
}