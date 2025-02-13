namespace LojaDoValdir.Modules;

public static class EnderecoModule
{
    private static List<Endereco> listaEnderecos = new List<Endereco>
    {
        Endereco.Inserir("Rua Hércules Florence", "154", "Marapé", "Santos", "SP", Guid.Parse("6bcda3fa-16e3-4d90-974c-5d8b14fe7ea6")),
        Endereco.Inserir("Rua A", "912", "Jardim Sueli", "Atibaia", "SP", Guid.Parse("7a9c3246-6cfe-4e49-b6b3-2000d00369ab")),
        Endereco.Inserir("Rua São Miguel", "414", "Tupiry", "Praia Grande", "SP", Guid.Parse("296e2886-aa84-4023-9ffe-430f09b127fb"))
    };

    public static void MapEnderecoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/endereco").WithTags("Endereço");

        // I N S E R I R 
        group.MapPost("/inserir", (Endereco novoEndereco) =>
        {
            var endereco = Endereco.Inserir(novoEndereco.Logradouro, novoEndereco.Numero, novoEndereco.Bairro, novoEndereco.Cidade, novoEndereco.UF, novoEndereco.ClienteId);
            listaEnderecos.Add(endereco);

            return Results.Created($"/api/endereco/inserir/{endereco.Id}/", "Endereço cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var endereco = listaEnderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
            {
                return Results.NotFound("Endereço não encontrado.");
            }

            return Results.Ok(endereco);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaEnderecos);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, Endereco enderecoAtualizado) =>
        {
            var endereco = listaEnderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
            {
                return Results.NotFound("Endereço não encontrado.");
            }

            endereco = Endereco.Atualizar(endereco, enderecoAtualizado.Logradouro, enderecoAtualizado.Numero, enderecoAtualizado.Bairro, enderecoAtualizado.Cidade, enderecoAtualizado.UF);

            return Results.Ok(new { mensagem = "Endereço atualizado com sucesso!", endereco });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var endereco = listaEnderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
            {
                return Results.NotFound("Endereço não encontrado.");
            }

            endereco = Endereco.Remover(endereco);
            listaEnderecos.Remove(endereco);

            return Results.Ok(new { mensagem = "Endereço removido com sucesso!", endereco });
        });
    }
}