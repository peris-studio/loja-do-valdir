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

    public static Usuario Inserir(string nome, string email, string senha)
    {
        var novoUsuario = new Usuario()
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Email = email,
            Senha = senha,
            TipoUsuario = TipoUsuario.Usuario,
            DataCriacao = DateTime.Now,
            Ativo = true
        };
        return novoUsuario;
    }

    public static Usuario Atualizar(Usuario usuario, string nome, string email, string senha, TipoUsuario tipoUsuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo");
        }

        else
        {
            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha;
            usuario.TipoUsuario = tipoUsuario;
            usuario.DataAtualizacao = DateTime.Now;
            usuario.Ativo = true;

            return usuario;
        }
    }

    public static Usuario Remover(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "O usuário não pode ser nulo");
        }

        else
        {
            usuario.TipoUsuario = TipoUsuario.Usuario;
            usuario.DataDelecao = DateTime.Now;
            usuario.Ativo = false;

            return usuario;
        }
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | E-mail: {Email} | Senha: {"*".PadLeft(Senha.Length, '*')} | Tipo: {TipoUsuario} | Ativo: {Ativo}";
    }
}