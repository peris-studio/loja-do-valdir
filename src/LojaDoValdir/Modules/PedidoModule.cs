namespace LojaDoValdir.Modules;

public static class PedidoModule
{
    private static List<Pedido> listaPedidos = new List<Pedido>
    {
        Pedido.Inserir(Guid.Parse("6bcda3fa-16e3-4d90-974c-5d8b14fe7ea6"),
                       Guid.Parse("ffd14883-41a7-46c8-b1b8-706aca11d3b4"),
                       Guid.Parse("a63597d3-a5b1-493c-8779-0ac5aa0501d9"),
                       Guid.Parse("9e532084-a7fe-4bc6-8362-25bc43edb828"),
                       new DateOnly(2024, 06, 22)),
        Pedido.Inserir(Guid.Parse("7a9c3246-6cfe-4e49-b6b3-2000d00369ab"),
                       Guid.Parse("9a4c64af-497c-4c46-817b-0c54cb334c1a"),
                       Guid.Parse("b8e55cde-5d5f-467f-bb70-9d108d383750"),
                       Guid.Parse("a74293c0-6d46-4151-b159-4c50b22a19a9"),
                       new DateOnly(2024, 06, 23)),
        Pedido.Inserir(Guid.Parse("296e2886-aa84-4023-9ffe-430f09b127fb"),
                       Guid.Parse("9d807da0-c2b5-4f10-8983-23e4c1162a08"),
                       Guid.Parse("eb953cd6-5b1b-4dea-89a0-257b1fe4196c"),
                       Guid.Parse("c550ce44-5a46-41ae-8c86-486a9a43b839"),
                       new DateOnly(2024, 06, 21))
    };

    public static void MapPedidoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/pedido").WithTags("Pedido");

        // I N S E R I R 
        group.MapPost("/inserir", (Pedido novoPedido) =>
        {
            var pedido = Pedido.Inserir(novoPedido.ClienteId, novoPedido.EnderecoId, novoPedido.ContatoId, novoPedido.UsuarioId, novoPedido.PrevisaoEntrega);
            listaPedidos.Add(pedido);

            return Results.Created($"/api/pedido/inserir/{pedido.Id}", "Pedido cadastrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var pedido = listaPedidos.FirstOrDefault(c => c.Id == id);

            if (pedido == null)
            {
                return Results.NotFound("Pedido não encontrado.");
            }

            return Results.Ok(pedido);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaPedidos);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, Pedido pedidoAtualizado) =>
        {
            var pedido = listaPedidos.FirstOrDefault(c => c.Id == id);

            if (pedido == null)
            {
                return Results.NotFound("Pedido não encontrado.");
            }

            pedido = Pedido.Atualizar(pedido, pedidoAtualizado.EnderecoId, pedidoAtualizado.ContatoId, pedidoAtualizado.PrevisaoEntrega, pedidoAtualizado.Status);

            return Results.Ok(new { mensagem = "Pedido atualizado com sucesso!", pedido });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var pedido = listaPedidos.FirstOrDefault(c => c.Id == id);

            if (pedido == null)
            {
                return Results.NotFound("Pedido não encontrado.");
            }

            pedido = Pedido.Remover(pedido);
            listaPedidos.Remove(pedido);

            return Results.Ok(new { mensagem = "Pedido removido com sucesso!", pedido });
        });
    }
}