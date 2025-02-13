namespace LojaDoValdir.Modules;

public static class PedidoItemModule
{
    private static List<PedidoItem> listaPedidoItens = new List<PedidoItem>
    {
        PedidoItem.Inserir("1", "", 29.30, Guid.Parse("9e532084-a7fe-4bc6-8362-25bc43edb828"), Guid.Parse("61ff80c6-e0f8-4464-9b46-cedc817b2fce")),
        PedidoItem.Inserir("2", "", 100, Guid.Parse("a74293c0-6d46-4151-b159-4c50b22a19a9"), Guid.Parse("e161fbad-57f0-4e90-95ae-d99a01998bcc")),
        PedidoItem.Inserir("3", "", 73.20, Guid.Parse("c550ce44-5a46-41ae-8c86-486a9a43b839"), Guid.Parse("2fbfc5bc-a680-4e62-bf6c-1a41a1e08d1c"))
    };

    public static void MapPedidoItemEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/pedido-item").WithTags("Item de Pedido");

        // I N S E R I R 
        group.MapPost("/inserir", (PedidoItem novoPedidoItem) =>
        {
            var pedido = PedidoItem.Inserir(novoPedidoItem.Nome, novoPedidoItem.Descricao, novoPedidoItem.Preco, novoPedidoItem.PedidoId, novoPedidoItem.ItemId);
            listaPedidoItens.Add(pedido);

            return Results.Created($"/api/pedido-item/inserir/{pedido.Id}", "Item do pedido registrado com sucesso!");
        });

        // O B T E R    I D
        group.MapGet("/obter-por-id/{id}", (Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id inválido");
            }

            var pedidoItem = listaPedidoItens.FirstOrDefault(c => c.Id == id);

            if (pedidoItem == null)
            {
                return Results.NotFound("Pedido de item não encontrado.");
            }

            return Results.Ok(pedidoItem);
        });

        // L I S T A R
        group.MapGet("/listar", () =>
        {
            return Results.Ok(listaPedidoItens);
        });

        // A T U A L I Z A R
        group.MapPut("/atualizar/{id}", (Guid id, PedidoItem pedidoAtualizado) =>
        {
            var pedidoItem = listaPedidoItens.FirstOrDefault(c => c.Id == id);

            if (pedidoItem == null)
            {
                return Results.NotFound("Pedido não encontrado.");
            }

            pedidoItem = PedidoItem.Atualizar(pedidoItem, pedidoAtualizado.Nome, pedidoAtualizado.Descricao, pedidoAtualizado.Preco);

            return Results.Ok(new { mensagem = "Item do pedido atualizado com sucesso!", pedidoItem });
        });

        // R E M O V E R
        group.MapDelete("/remover/{id}", (Guid id) =>
        {
            var pedidoItem = listaPedidoItens.FirstOrDefault(c => c.Id == id);

            if (pedidoItem == null)
            {
                return Results.NotFound("Pedido de item não encontrado.");
            }

            pedidoItem = PedidoItem.Remover(pedidoItem);
            listaPedidoItens.Remove(pedidoItem);

            return Results.Ok(new { mensagem = "Item do pedido removido com sucesso!", pedidoItem });
        });
    }
}