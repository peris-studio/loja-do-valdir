namespace LojaDoValdir.Modules;

public static class ItemDescontoModule
{
    private static List<ItemDesconto> listaItensDescontados = new List<ItemDesconto>
    {
        ItemDesconto.Inserir("Leite Fermentado Yakult", 5.90, 80, 1.80, new DateTime(2024, 06, 02), new DateTime(2024, 06, 22),
                            Guid.Parse("61ff80c6-e0f8-4464-9b46-cedc817b2fce")),
        ItemDesconto.Inserir("Pão Francês", 0.50, 50, 0.25, new DateTime(2024, 09, 30), new DateTime(2024, 10, 03),
                            Guid.Parse("e161fbad-57f0-4e90-95ae-d99a01998bcc")),
        ItemDesconto.Inserir("Maçã Gala", 1.29, 10, 1.17, new DateTime(2024, 02, 18), new DateTime(2024, 03, 25),
                            Guid.Parse("2fbfc5bc-a680-4e62-bf6c-1a41a1e08d1c"))
    };

    public static void MapItemDescontoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/desconto").WithTags("Desconto");

        // I N S E R I R 
        group.MapPost("/inserir", (ItemDesconto novoDesconto) =>
        {
            var desconto = ItemDesconto.Inserir(novoDesconto.Nome, novoDesconto.PrecoComum, novoDesconto.PorcentagemDesconto, novoDesconto.PrecoDescontado, novoDesconto.DataInicio, novoDesconto.DataTermino, novoDesconto.ItemId);
            listaItensDescontados.Add(desconto);

            return Results.Created($"/api/desconto/inserir/{desconto.Id}/", "Desconto cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var desconto = listaItensDescontados.FirstOrDefault(c => c.Id == id);

            if (desconto == null)
            {
                return Results.NotFound("Desconto não encontrado.");
            }

            return Results.Ok(desconto);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaItensDescontados);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, ItemDesconto descontoAtualizado) =>
        {
            var desconto = listaItensDescontados.FirstOrDefault(c => c.Id == id);

            if (desconto == null)
            {
                return Results.NotFound("Desconto não encontrado.");
            }

            desconto = ItemDesconto.Atualizar(desconto, descontoAtualizado.Nome, descontoAtualizado.PrecoComum, descontoAtualizado.PorcentagemDesconto, descontoAtualizado.PrecoDescontado, descontoAtualizado.DataInicio, descontoAtualizado.DataTermino);

            return Results.Ok(new { mensagem = "Desconto atualizado com sucesso!", desconto });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var desconto = listaItensDescontados.FirstOrDefault(c => c.Id == id);

            if (desconto == null)
            {
                return Results.NotFound("Desconto não encontrado.");
            }

            desconto = ItemDesconto.Remover(desconto);
            listaItensDescontados.Remove(desconto);

            return Results.Ok(new { mensagem = "Desconto removido com sucesso!", desconto });
        });
    }
}