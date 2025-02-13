namespace LojaDoValdir.Modules;

public static class UsuarioModule
{
    private static List<Usuario> listaUsuarios = new List<Usuario>
    {
        Usuario.Inserir("Cauã Fernado", "caua.fernando@jetstar.com.br", "QEf3QeTi2w"), // Id = Guid.Parse("dcce74a1-af05-4ed3-8a61-1d1969eff104"),
        Usuario.Inserir("Francisco", "francisco12345@gmail.com", "F5KKtwLflu"), // Id = Guid.Parse("7dd48cf2-dad6-409b-8a5f-45c0e9dcb919"),
        Usuario.Inserir("Sônia Helena", "sonia_helena_gatinha@sabesp.com.br", "RSTK7plbqn") // Id = Guid.Parse("3051ae3a-602b-4fa8-8328-3b80efa41c4e"),
    };

    public static void MapUsuarioEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/usuario").WithTags("Usuário");

        // I N S E R I R 
        group.MapPost("/inserir", (Usuario novoUsuario) =>
        {
            var usuario = Usuario.Inserir(novoUsuario.Nome, novoUsuario.Email, novoUsuario.Senha);
            listaUsuarios.Add(usuario);

            return Results.Created($"/api/usuario/inserir/{usuario.Id}", "Usuário cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var usuario = listaUsuarios.FirstOrDefault(c => c.Id == id);

            if (usuario == null)
            {
                return Results.NotFound("Usuário não encontrado.");
            }

            return Results.Ok(usuario);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaUsuarios);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, Usuario usuarioAtualizado) =>
        {
            var usuario = listaUsuarios.FirstOrDefault(c => c.Id == id);

            if (usuario == null)
            {
                return Results.NotFound("Usuário não encontrado.");
            }

            usuario = Usuario.Atualizar(usuario, usuarioAtualizado.Nome, usuarioAtualizado.Email, usuarioAtualizado.Senha, usuarioAtualizado.TipoUsuario);

            return Results.Ok(new { mensagem = "Usuário atualizado com sucesso!", usuario });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var usuario = listaUsuarios.FirstOrDefault(c => c.Id == id);

            if (usuario == null)
            {
                return Results.NotFound("Usuário não encontrado.");
            }

            usuario = Usuario.Remover(usuario);
            listaUsuarios.Remove(usuario);

            return Results.Ok(new { mensagem = "Usuário removido com sucesso!", usuario });
        });
    }
}