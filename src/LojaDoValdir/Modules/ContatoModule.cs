namespace LojaDoValdir.Modules;

public static class ContatoModule
{
    private static List<Contato> listaContatos = new List<Contato>
    {
        Contato.Inserir("+55", "71", "983623115", true, Guid.Parse("6bcda3fa-16e3-4d90-974c-5d8b14fe7ea6")),
        Contato.Inserir("+55", "11", "995351893", true, Guid.Parse("7a9c3246-6cfe-4e49-b6b3-2000d00369ab")),
        Contato.Inserir("+55", "13", "988390610", true, Guid.Parse("296e2886-aa84-4023-9ffe-430f09b127fb"))
    };

    public static void MapContatoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/contato").WithTags("Contato");

        // I N S E R I R 
        group.MapPost("/inserir", (Contato novoContato) =>
        {
            var contato = Contato.Inserir(novoContato.CodigoDDI, novoContato.CodigoDDD, novoContato.CodigoTelefone, novoContato.TelefonePrincipal, novoContato.ClienteId);
            listaContatos.Add(contato);

            return Results.Created($"/api/contato/inserir/{contato.Id}/", "Contato cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var contato = listaContatos.FirstOrDefault(c => c.Id == id);

            if (contato == null)
            {
                return Results.NotFound("Contato não encontrado.");
            }

            return Results.Ok(contato);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaContatos);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, Contato contatoAtualizado) =>
        {
            var contato = listaContatos.FirstOrDefault(c => c.Id == id);

            if (contato == null)
            {
                return Results.NotFound("Contato não encontrado.");
            }

            contato = Contato.Atualizar(contato, contatoAtualizado.CodigoDDI, contatoAtualizado.CodigoDDD, contatoAtualizado.CodigoTelefone, contatoAtualizado.TelefonePrincipal);

            return Results.Ok(new { mensagem = "Contato atualizado com sucesso!", contato });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var contato = listaContatos.FirstOrDefault(c => c.Id == id);

            if (contato == null)
            {
                return Results.NotFound("Contato não encontrado.");
            }

            contato = Contato.Remover(contato);
            listaContatos.Remove(contato);

            return Results.Ok(new { mensagem = "Contato removido com sucesso!", contato });
        });
    }
}